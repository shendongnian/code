    public class LimitedConverter : JavaScriptConverter
    {
        const string StuffName = "Stuff";
        const string StatusName = "Status";
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            var limited = new Limited();
            object value;
            if (dictionary.TryGetValue(StuffName, out value))
            {
                // limited.Stuff = serializer.ConvertToType<string>(value); // Actually it's get only.
            }
            if (dictionary.TryGetValue(StatusName, out value))
            {
                limited.Status = serializer.ConvertToType<LimitedStatus>(value);
            }
            return limited;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var limited = (Limited)obj;
            if (limited == null)
                return null;
            var dict = new Dictionary<string, object>();
            if (limited.Stuff != null)
                dict.Add(StuffName, limited.Stuff);
            if (limited.Status != null)
                dict.Add(StatusName, limited.Status);
            return dict;
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new [] { typeof(Limited) } ; }
        }
    }
