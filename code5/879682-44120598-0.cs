    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    namespace JSON_Helper
    {
        public static class JSON
        {
            private static JavaScriptSerializer Serializer { get; } = new JavaScriptSerializer();
            public static string Encode(object JsonObject)
            {
                return Serializer.Serialize(JsonObject);
            }
            public static T Decode<T>(string JsonString)
            {
                return Serializer.Deserialize<T>(JsonString);
            }
            public static dynamic Decode(string JsonString)
            {
                var deserialized = Serializer.Deserialize<dynamic>(JsonString);
                dynamic result = new System.Dynamic.ExpandoObject();
                foreach (KeyValuePair<string, object> item in deserialized)
                {
                    ((IDictionary<string, object>)result).Add(item.Key, item.Value);
                }
                return result;
            }
        }
    }
