    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    [AttributeUsage(AttributeTargets.Property)]
    public class TypeAttribute : Attribute
    {
        private Type _type;
        public Type Type
        {
            get { return _type; }
        }
    
        public TypeAttribute(Type t)
        {
            _type = t;
        }
    }
    
    public class BaseClass
    {
    
    }
    
    static class Program
    {
        static void Main()
        {
            var aName = new AssemblyName("MyAssembly");
            var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(
                    aName, AssemblyBuilderAccess.RunAndSave);
            var mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
            var tb = mb.DefineType("MyType", TypeAttributes.Public, typeof(BaseClass));
    
            var propertyName = "MyProperty";
            var propertyType = typeof(int);
            var propertyBuilder = tb.DefineProperty(propertyName,
               PropertyAttributes.HasDefault, propertyType, null);
            var classCtorInfo = typeof(TypeAttribute).
                       GetConstructor(new Type[] { typeof(Type) });
    
            Type tArg = typeof(float); // for no real reason
            var myCABuilder = new CustomAttributeBuilder(
                classCtorInfo, new object[] { tArg });
            propertyBuilder.SetCustomAttribute(myCABuilder);
    
            var field = tb.DefineField("myField", propertyType, FieldAttributes.Private);
            var getter = tb.DefineMethod("get_" + propertyName,
                MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.Public,
                propertyType, Type.EmptyTypes);
            propertyBuilder.SetGetMethod(getter);
            var il = getter.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, field);
            il.Emit(OpCodes.Ret);
            var setter = tb.DefineMethod("set_" + propertyName,
                MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.Public,
                typeof(void), new[] { typeof(int) });
            il = setter.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Stfld, field);
            il.Emit(OpCodes.Ret);
            propertyBuilder.SetSetMethod(setter);
            var target = Activator.CreateInstance(tb.CreateType());        
            
            List<PropertyInfo> result = target.GetType()
              .GetProperties()
              .Where(
                 p =>
                    p.GetCustomAttributes(typeof(TypeAttribute), true)
                     //.Where(ca => ((TypeAttribute)ca).)
                    .Any()
                 ).ToList();
        }
    }
