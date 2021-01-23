    class KvpJavaScriptConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new List<Type> { typeof(KeyValuePair<string, object>) }; }
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            KeyValuePair<string, object> kvp = (KeyValuePair<string, object>)obj;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add(kvp.Key, kvp.Value);
            return dict;
        }
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
