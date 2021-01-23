    class SpecialEnumUserType : ImmutableUserType
    {
        public override object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            TheSpecialEnum value;
            if (Enum.TryParse<TheSpecialEnum>((string)rs[names[0]], out value))
                return value;
            else
                return default(TheSpecialEnum);
        }
    
        public override void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            NHibernateUtil.String.NullSafeSet(cmd, value.ToString(), index);
        }
    
        public override Type ReturnedType
        {
            get { return typeof(TheSpecialEnum); }
        }
    
        public override SqlType[] SqlTypes
        {
            get { return new[] { SqlTypeFactory.GetString(50) }; }
        }
    }
