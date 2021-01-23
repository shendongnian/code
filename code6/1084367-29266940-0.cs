    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Web;
    using System.Reflection;
    using System.Linq.Expressions;
    namespace MyProject.ODataExtensions
    {
    public static class ODataExtensions
    {
        public static void Patch<TEntityType>(this System.Web.OData.Delta<TEntityType> d, TEntityType original, String[] includedProperties, String[] excludedProperties) where TEntityType : class
        {
            Dictionary<string, PropertyAccessor<TEntityType>> _propertiesThatExist = InitializePropertiesThatExist<TEntityType>();
            var changedProperties = d.GetChangedPropertyNames();
            if (includedProperties != null) changedProperties = changedProperties.Intersect(includedProperties);
            if (excludedProperties != null) changedProperties = changedProperties.Except(excludedProperties);
            PropertyAccessor<TEntityType>[] array = (
                    from s in changedProperties
                    select _propertiesThatExist[s]).ToArray();
            var array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                PropertyAccessor<TEntityType> propertyAccessor = array2[i];
                propertyAccessor.Copy(d.GetEntity(), original);
            }
     
        }
        private static Dictionary<string, PropertyAccessor<T>> InitializePropertiesThatExist<T>() where T : class
        {
            Type backingType = typeof(T);
            return backingType.GetProperties()
                                .Where(p => p.GetSetMethod() != null && p.GetGetMethod() != null)
                                .Select<PropertyInfo, PropertyAccessor<T>>(p => new CompiledPropertyAccessor<T>(p))
                                .ToDictionary(p => p.Property.Name);
        }
        internal abstract class PropertyAccessor<TEntityType> where TEntityType : class
        {
            protected PropertyAccessor(PropertyInfo property)
            {
                if (property == null)
                {
                    throw new System.ArgumentException("Property cannot be null","property");
                }
                Property = property;
                if (Property.GetGetMethod() == null || Property.GetSetMethod() == null)
                {
                    throw new System.ArgumentException("Property must have public setter and getter", "property");
                }
            }
            public PropertyInfo Property
            {
                get;
                private set;
            }
            public void Copy(TEntityType from, TEntityType to)
            {
                if (from == null)
                {
                    throw new System.ArgumentException("Argument cannot be null", "from");
                }
                if (to == null)
                {
                    throw new System.ArgumentException("Argument cannot be null", "to");
                }
                SetValue(to, GetValue(from));
            }
            public abstract object GetValue(TEntityType entity);
            public abstract void SetValue(TEntityType entity, object value);
        }
        internal class CompiledPropertyAccessor<TEntityType> : PropertyAccessor<TEntityType> where TEntityType : class
        {
            private Action<TEntityType, object> _setter;
            private Func<TEntityType, object> _getter;
            public CompiledPropertyAccessor(PropertyInfo property)
                : base(property)
            {
                _setter = MakeSetter(Property);
                _getter = MakeGetter(Property);
            }
            public override object GetValue(TEntityType entity)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                return _getter(entity);
            }
            public override void SetValue(TEntityType entity, object value)
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _setter(entity, value);
            }
            private static Action<TEntityType, object> MakeSetter(PropertyInfo property)
            {
                Type type = typeof(TEntityType);
                ParameterExpression entityParameter = Expression.Parameter(type);
                ParameterExpression objectParameter = Expression.Parameter(typeof(Object));
                MemberExpression toProperty = Expression.Property(Expression.TypeAs(entityParameter, property.DeclaringType), property);
                UnaryExpression fromValue = Expression.Convert(objectParameter, property.PropertyType);
                BinaryExpression assignment = Expression.Assign(toProperty, fromValue);
                Expression<Action<TEntityType, object>> lambda = Expression.Lambda<Action<TEntityType, object>>(assignment, entityParameter, objectParameter);
                return lambda.Compile();
            }
            private static Func<TEntityType, object> MakeGetter(PropertyInfo property)
            {
                Type type = typeof(TEntityType);
                ParameterExpression entityParameter = Expression.Parameter(type);
                MemberExpression fromProperty = Expression.Property(Expression.TypeAs(entityParameter, property.DeclaringType), property);
                UnaryExpression convert = Expression.Convert(fromProperty, typeof(Object));
                Expression<Func<TEntityType, object>> lambda = Expression.Lambda<Func<TEntityType, object>>(convert, entityParameter);
                return lambda.Compile();
            }
        }
    }
}
