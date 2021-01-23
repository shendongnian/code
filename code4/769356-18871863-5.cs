    public class MyJavaScriptConverter : JavaScriptConverter
    {
        private static readonly Type[] supportedTypes = new[] { typeof(JsonClass) };
    
        public override IEnumerable<Type> SupportedTypes
        {
            get { return supportedTypes; }
        }
    
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (type == typeof(JsonClass))
            {
                var result = new JsonClass();
                object productId;
                if (dictionary.TryGetValue("ea:productionId", out productId))
                {
                    result.ProductId = serializer.ConvertToType<string>(productId);
                }
                ... so on for the other properties
                
                return result;
            }
    
            return null;
        }
    
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
