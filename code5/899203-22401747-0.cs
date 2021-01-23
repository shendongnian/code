    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace VmsSendUtil
    {
        /// <summary> Serializes and Deserializes any object to and from string </summary>
        public static class StringSerializer
        {
            ///<summary> Serializes object to string </summary>
            ///<param name="obj"> Object to serialize </param>
            ///<returns> Xml string with serialized object </returns>
            public static string Serialize<T>(T obj)
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
    
                var stringSerializer = new StringSerializer<T>();
                return stringSerializer.Serialize(obj);
            }
    
            /// <summary> Deserializes object from string. </summary>
            /// <param name="xml"> String with serialization XML data </param>
            public static T Deserialize<T>(string xml)
            {
                Contract.Requires(!string.IsNullOrEmpty(xml));
                Contract.Ensures(!Equals(Contract.Result<T>(), null));
    
                var stringSerializer = new StringSerializer<T>();
                return stringSerializer.Deserialize(xml);
            }
        }
    
        /// <summary> Serializes and Deserializes any object to and from string </summary>
        public class StringSerializer<T>
        {
            [ContractInvariantMethod]
            private void ObjectInvariant()
            {
                Contract.Invariant(_serializer != null);
            }
    
            private readonly XmlSerializer _serializer = new XmlSerializer(typeof(T));
    
            ///<summary> Serializes object to string </summary>
            ///<param name="obj"> Object to serialize </param>
            ///<returns> Xml string with serialized object </returns>
            public string Serialize(T obj)
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
    
                var sb = new StringBuilder();
                using (var sw = new StringWriter(sb, CultureInfo.InvariantCulture))
                {
                    var tw = new XmlTextWriter(sw) { Formatting = Formatting.Indented };
                    _serializer.Serialize(tw, obj);
                }
                string result = sb.ToString();
                Contract.Assume(!string.IsNullOrEmpty(result));
                return result;
            }
    
            /// <summary> Deserializes object from string. </summary>
            /// <param name="xml"> String with serialization XML data </param>
            public T Deserialize(string xml)
            {
                Contract.Requires(!string.IsNullOrEmpty(xml));
                Contract.Ensures(!Equals(Contract.Result<T>(), null));
    
                using (var stringReader = new StringReader(xml))
                {
                    // Switch off CheckCharacters to deserialize special characters
                    var xmlReaderSettings = new XmlReaderSettings { CheckCharacters = false };
    
                    var xmlReader = XmlReader.Create(stringReader, xmlReaderSettings);
                    var result = (T)_serializer.Deserialize(xmlReader);
                    Contract.Assume(!Equals(result, null));
                    return result;
                }
            }
        }
    }
