    using System;
    using System.Text;
    using System.Runtime.Serialization.Json;
    using System.IO;
    
    namespace Utilities
    {
        /// <summary>
        /// Group of static methods for dealing with JSON.
        /// </summary>
        public static class JsonTools
        {
            /// <summary>
            /// Serializes an object to JSON string.
            /// </summary>
            /// <param name="obj">The object to serialize. </param>
            /// <returns></returns>
            /// <exception cref="System.Runtime.Serialization.InvalidDataContractException"></exception>
            /// <exception cref="System.Runtime.Serialization.SerializationException"></exception>
            /// <exception cref="System.ServiceModel.QuotaExceededExceptionn"></exception>        
            public static string ObjectToJsonString(object obj)
            {
                try
                {
                    MemoryStream jsonStream = new MemoryStream();
                    DataContractJsonSerializer js = new DataContractJsonSerializer(obj.GetType());
                    js.WriteObject(jsonStream, obj);
                    jsonStream.Position = 0;
    
                    StreamReader sr = new StreamReader(jsonStream);
                    return sr.ReadToEnd();
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            /// <summary>
            /// Serializes an object to JSON byte array.
            /// </summary>
            /// <param name="obj">The object to serialize. </param>
            /// <returns></returns>
            /// <exception cref="System.Runtime.Serialization.InvalidDataContractException"></exception>
            /// <exception cref="System.Runtime.Serialization.SerializationException"></exception>
            /// <exception cref="System.ServiceModel.QuotaExceededExceptionn"></exception>  
            public static byte[] ObjectToJsonByteArray(object obj)
            {
                try
                {
                    MemoryStream jsonStream = new MemoryStream();
                    DataContractJsonSerializer js = new DataContractJsonSerializer(obj.GetType());
                    js.WriteObject(jsonStream, obj);
                    jsonStream.Position = 0;
    
                    return jsonStream.ToArray();
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
    
            /// <summary>
            /// Deserializes a JSON formatted string to an object of the defined type
            /// </summary>
            /// <param name="jsonString">JSON formatted string</param>
            /// <param name="objType">The type of the object which the jsonString is to be Deserialized to.</param>
            /// <returns>Deserialized object</returns>
            /// <exception cref="System.Runtime.Serialization.SerializationException"></exception>
            public static object JsonStringToObject(string jsonString, Type objType)
            {
                try
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(objType);
                    byte[] jsonBytes = Encoding.Default.GetBytes(jsonString);
                    MemoryStream jsonStream = new MemoryStream(jsonBytes);
    
                    return js.ReadObject(jsonStream);
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            /// <summary>
            /// Deserializes a JSON formatted byte array to an object of the defined type
            /// </summary>
            /// <param name="jsonBytes">JSON formatted byte array</param>
            /// <param name="objType">The type of the object which the jsonString is to be Deserialized to.</param>
            /// <returns>Deserialized object</returns>
            /// <exception cref="System.Runtime.Serialization.SerializationException"></exception>
            public static object JsonByteArrayToObject(byte[] jsonBytes, Type objType)
            {
                try
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(objType);
                    MemoryStream jsonStream = new MemoryStream(jsonBytes);
    
                    return js.ReadObject(jsonStream);
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
    
        }
    }
