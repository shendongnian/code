    namespace Test
    {
        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;
        using System;
        using System.Collections;
        using System.Reflection;
    
        /// <summary>
        /// Defines the custom JSON Converter of collection type that serialize collection to an array of ID for Ember.
        /// </summary>
        public class CustomConverter : JsonConverter
        {
            /// <summary>
            /// Define the property name that is define in the collection type.
            /// </summary>
            private readonly string IDKEY = "Id";
    
            private readonly string MSGKEY = "Msg";
    
            private readonly string TIMEKEY = "Timestamp";
    
            /// <summary>
            /// It is write only convertor and it cannot be read back.
            /// </summary>
            public override bool CanRead
            {
                get { return false; }
            }
    
            /// <summary>
            /// Validate that this conversion can be applied on IEnumerable type only.
            /// </summary>
            /// <param name="objectType">type of object</param>
            /// <returns>Validated value in boolean</returns>
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(Message);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            /// <summary>
            /// Write JSON data from IEnumerable to Array.
            /// </summary>
            /// <param name="writer">JSON Writer</param>
            /// <param name="value">Value of an object</param>
            /// <param name="serializer">JSON Serializer object</param>
            public override void WriteJson(JsonWriter writer, object item, JsonSerializer serializer)
            {
                JArray array = new JArray();
                PropertyInfo prop = item.GetType().GetProperty(IDKEY);
                if (prop != null && prop.CanRead)
                {
                    array.Add(JToken.FromObject(prop.GetValue(item, null)));
                }
    
                prop = item.GetType().GetProperty(MSGKEY);
                if (prop != null && prop.CanRead)
                {
                    array.Add(JToken.FromObject(prop.GetValue(item, null)));
                }
    
                prop = item.GetType().GetProperty(TIMEKEY);
                if (prop != null && prop.CanRead)
                {
                    array.Add(JToken.FromObject(prop.GetValue(item, null)));
                }
    
    
                array.WriteTo(writer);
            }
        }
    }
