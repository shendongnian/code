    class SpecialEnumUserType<TEnum> : ImmutableUserType
    {
        public override object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            TEnum value;
            if (Enum.TryParse<TEnum>((string)rs[names[0]], out value))
                return value;
            else
                return default(TEnum);
        }
    
        public override void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            NHibernateUtil.String.NullSafeSet(cmd, value.ToString(), index);
        }
    
        public override Type ReturnedType
        {
            get { return typeof(TEnum); }
        }
    
        public override SqlType[] SqlTypes
        {
            get { return new[] { SqlTypeFactory.GetString(50) }; }
        }
    }
