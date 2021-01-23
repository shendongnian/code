    public class VersionAgnosticType : ImmutableUserType 
    {
        public override object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            return Type.GetType((string)NHibernateUtil.String.Get(rs, names[0]));
        }
    
        public override void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var type = (Type)value;
            NHibernateUtil.String.Set(cmd, type.FullName + "," + type.Assembly.GetName().Name, index);
        }
    
        public override Type ReturnedType
        {
            get { return typeof(Type); }
        }
    
        public override SqlType[] SqlTypes
        {
            get { return new[] { SqlTypeFactory.GetString(255) }; }
        }
    }
    public class TypePropertyConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Type == typeof(Type))
                instance.CustomType<VersionAgnosticType>();
        }
    }
