    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public abstract class EntityAttribute : Attribute
    {
        internal abstract IEnumerable<EntityColumn> GetColumns(object instance, PropertyInfo property);
    }
