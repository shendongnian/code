    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;
    namespace TryOuts
    {
        static class SO_28768330
        {
            public static class Mapper
            {
                private static readonly List<Type> _typesAsPrimitive;
                private static readonly ConcurrentDictionary<Type, MapEntry> _map;
                private static Lazy<AssemblyName> MyDynamicAssemblyName;
                private static Lazy<AssemblyBuilder> MyDynamicAssemblyBuilder;
                private static Lazy<ModuleBuilder> MyDynamicModuleBuilder;
                static Mapper() 
                {
                    _typesAsPrimitive = new List<Type>() { 
                        typeof(string), typeof(DateTime), typeof(TimeSpan), typeof(DateTimeOffset) 
                    };
                    _map = new ConcurrentDictionary<Type, MapEntry>();
                    MyDynamicAssemblyName = new Lazy<AssemblyName>(
                        () => new AssemblyName("__My_Dynamic_Assembly__"), 
                        true);
                    MyDynamicAssemblyBuilder = new Lazy<AssemblyBuilder>(
                        () => AppDomain.CurrentDomain.DefineDynamicAssembly(MyDynamicAssemblyName.Value, AssemblyBuilderAccess.Run), 
                        true);
                    MyDynamicModuleBuilder = new Lazy<ModuleBuilder>(
                        () => MyDynamicAssemblyBuilder.Value.DefineDynamicModule("__My_Dynamic_Module__"),
                        true);
                }
                public static object FlattenToAnon<T>(T instance) where T : class
                {
                    var entry = _map.GetOrAdd(typeof(T), BuildMapEntry<T>());
                    return (instance != null) ? entry.Factory(instance) : instance;
                }
                private class MapEntry
                {
                    public Type DynamicType;
                    public Func<object, object> Factory;
                }
                private static MapEntry BuildMapEntry<T>()
                {
                    var mapEntry = new MapEntry();
                    var mappedType = typeof(T);
                    var dynamicTypeName = "__Dynamic__" + mappedType.Name;
                    var typeBuilder = MyDynamicModuleBuilder.Value.DefineType(dynamicTypeName, TypeAttributes.Public);
                    var getterList = new List<Func<object, object>>();
                    var setterList = new List<Action<object, object>>();
                    var propertiesToMap = GetSourcePropertiesFor<T>(getterList);
                    var mappedProperties = new List<PropertyBuilder>(propertiesToMap.Count);
                    foreach (var p in propertiesToMap)
                    {
                        var pb = AddProperty(typeBuilder, p.Name, p.PropertyType);
                        mappedProperties.Add(pb);
                    }
                    //OverrideToString(typeBuilder, mappedProperties);
                    mapEntry.DynamicType = typeBuilder.CreateType();
                    foreach (var p in mapEntry.DynamicType.GetProperties())
                        setterList.Add(BuildSetter(p));
                    mapEntry.Factory = input =>
                    {
                        var instance = Activator.CreateInstance(mapEntry.DynamicType);
                        for (var i = 0; i < getterList.Count(); i++)
                            setterList[i](instance, getterList[i](input));
                        return instance;
                    };
                    return mapEntry;
                }
                private static List<PropertyInfo> GetSourcePropertiesFor<T>(List<Func<object, object>> getters)
                {
                    var props = new List<PropertyInfo>();
                    var ps = typeof(T).GetProperties();
                    foreach (var p in ps)
                    {
                        var getter = BuildGetter(p);
                        if (!GetNestedSourceProperties(props, getters, p, getter))
                        {
                            props.Add(p);
                            getters.Add(getter);
                        }
                    }
                    return props;
                }
                private static bool GetNestedSourceProperties(List<PropertyInfo> props, List<Func<object, object>> getters, PropertyInfo nested, Func<object, object> parent_getter)
                {
                    if (nested.PropertyType.IsPrimitive || _typesAsPrimitive.Contains(nested.PropertyType))
                        return false;
                    var ps = nested.PropertyType.GetProperties();
                    if (ps.Length == 0)
                        return false;
                    foreach (var p in ps)
                    {
                        var prop_getter = BuildGetter(p);
                        var getter = new Func<object, object>(obj => prop_getter(parent_getter(obj)));
                        if (!GetNestedSourceProperties(props, getters, p, getter))
                        {
                            props.Add(p);
                            getters.Add(getter);
                        }
                    }
                    return true;
                }
                private static Func<object, object> BuildGetter(PropertyInfo propertyInfo)
                {
                    var instance = Expression.Parameter(typeof(object), "instance");
                    var instanceCast = propertyInfo.DeclaringType.IsValueType
                        ? Expression.Convert(instance, propertyInfo.DeclaringType)
                        : Expression.TypeAs(instance, propertyInfo.DeclaringType);
                    var propertyCast = Expression.TypeAs(Expression.Property(instanceCast, propertyInfo), typeof(object));
                    return Expression.Lambda<Func<object, object>>(propertyCast, instance).Compile();
                }
                private static Action<object, object> BuildSetter(PropertyInfo propertyInfo)
                {
                    var setMethodInfo = propertyInfo.GetSetMethod(true);
                    var instance = Expression.Parameter(typeof(object), "instance");
                    var value = Expression.Parameter(typeof(object), "value");
                    var instanceCast = propertyInfo.DeclaringType.IsValueType
                        ? Expression.Convert(instance, propertyInfo.DeclaringType)
                        : Expression.TypeAs(instance, propertyInfo.DeclaringType);
                    var call = Expression.Call(instanceCast, setMethodInfo, Expression.Convert(value, propertyInfo.PropertyType));
                    return Expression.Lambda<Action<object, object>>(call, instance, value).Compile();
                }
                private static PropertyBuilder AddProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType)
                {
                    const MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
                    var field = typeBuilder.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);
                    var property = typeBuilder.DefineProperty(
                        propertyName, PropertyAttributes.None, propertyType, new[] { propertyType });
                    var getMethodBuilder = typeBuilder.DefineMethod("get_" + propertyName, getSetAttr, propertyType, Type.EmptyTypes);
                    var getIl = getMethodBuilder.GetILGenerator();
                    getIl.Emit(OpCodes.Ldarg_0);
                    getIl.Emit(OpCodes.Ldfld, field);
                    getIl.Emit(OpCodes.Ret);
                    property.SetGetMethod(getMethodBuilder);
                    var setMethodBuilder = typeBuilder.DefineMethod("set_" + propertyName, getSetAttr, null, new[] { propertyType });
                    var setIl = setMethodBuilder.GetILGenerator();
                    setIl.Emit(OpCodes.Ldarg_0);
                    setIl.Emit(OpCodes.Ldarg_1);
                    setIl.Emit(OpCodes.Stfld, field);
                    setIl.Emit(OpCodes.Ret);
                    property.SetSetMethod(setMethodBuilder);
                    return property;
                }
            }
            public class Address 
            {
                public string Street { get; set; }
                public string City { get; set; }
            }
            public class Person
            {
                public string Name { get; set; }
                public int Age { get; set; }
                public Address Address { get; set; }
            }
            public static void TryIt()
            {
                var aPerson = new Person() { Age = 30, Name = "Joe Plummer", Address = new Address() { City = "Gotham", Street = "First Bat Street" } };
                var flattenedPerson = Mapper.FlattenToAnon(aPerson);
                var dynamicPerson = (dynamic)flattenedPerson;
                Console.WriteLine("Name   = {0}", dynamicPerson.Name);
                Console.WriteLine("Age    = {0}", dynamicPerson.Age);
                Console.WriteLine("City   = {0}", dynamicPerson.City);
                Console.WriteLine("Street = {0}", dynamicPerson.Street);
            }
        }
    }
