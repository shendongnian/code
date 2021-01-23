    public class Base
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
    public class Alpha : Base
    {
        public virtual CustomData Custom { get; set; }
        public class CustomData
        {
            public string Foo { get; set; }
            public int Bar { get; set; }
        }
    }
    // NHibernate mapping
    public class AlphaMapping : SubclassMapping<Alpha>
    {
        public AlphaMapping()
        {
            Property(a => a.Custom, m => 
            {
                // tell NHibernate to use custom type
                m.Type<JsonType<Alpha.CustomData>>();
            });
        }
    }
    // NHibernate UserType to serialize object to json and back
    public class JsonType<T> : IUserType
    {
        public object NullSafeGet(System.Data.IDataReader rs, string[] names, object owner)
        {
            var json = NHibernateUtil.String.NullSafeGet(rs, names[0]) as string;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
        public void NullSafeSet(System.Data.IDbCommand cmd, object value, int index)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            NHibernateUtil.String.NullSafeSet(cmd, json, index);
        }
    }
