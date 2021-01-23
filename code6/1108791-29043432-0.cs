    public class MyDomainObject
    {
        public string MyProperty { get; set; }
    }
    [DataContract]
    public class MyDomainObjectWcfAdapter
    {
        private readonly MyDomainObject _object;
        public MyDomainObjectWcfAdapter(MyDomainObject obj)
        {
            this._object = obj;
        }
        [DataMember]
        public string MyProperty
        {
            get { return this._object.MyProperty; }
            set { this._object.MyProperty = value; }
        }
        public MyDomainObject GetObject()
        {
            return this._object;
        }
    }
