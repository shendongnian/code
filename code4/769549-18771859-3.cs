    public class SerializableDictionaryType : IUserType
    {
        public new bool Equals(object x, object y)
        {
            return x != null && x.Equals(y);
        }
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            string dbString = (string) NHibernateUtil.String.NullSafeGet(rs, names);
            SerializableDictionary dict = JsonConvert.DeserializeObject<SerializableDictionary>(dbString);
            return dict;
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value == null)
            {
                NHibernateUtil.String.NullSafeSet(cmd, null, index);
                return;
            }
            value = value.ToString();
            NHibernateUtil.String.NullSafeSet(cmd, value, index);
        }
        public object DeepCopy(object value)
        {
            if (value == null) return null;
            SerializableDictionary newDict = new SerializableDictionary();
            foreach (KeyValuePair<string, object> item in (SerializableDictionary)value)
            {
                newDict.Add(item.Key, item.Value);
            }
            return newDict;
        }
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
        public object Assemble(object cached, object owner)
        {
            return JsonConvert.DeserializeObject<SerializableDictionary>(cached.ToString());
        }
        public object Disassemble(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
        public SqlType[] SqlTypes
        {
            get
            {
                SqlType[] types = new SqlType[1];
                types[0] = new SqlType(DbType.String);
                return types;
            }
        }
        public Type ReturnedType
        {
            get { return typeof (SerializableDictionary); }
        }
        public bool IsMutable
        {
            get { return false; }
        }
    }
