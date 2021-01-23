    /// <summary>
    /// Synthetic class to set in StreamingContext.Context
    /// </summary>
    public sealed class JsonStreamingContext
    {
        public JsonStreamingContext()
        {
        }
    }
    [DataContract]
    [Serializable]
    public partial class SyncablePackage : ISerializable
    {
        public SyncablePackage() { }
        public SyncablePackage(SerializationInfo info, StreamingContext ctxt)
        {
            if (ctxt.Context is JsonStreamingContext)
            {
                var jObj = (JObject)info.GetValue("Data", typeof(JObject));
                if (jObj != null)
                    DataWrapper = jObj.ToObject<object>(new JsonSerializer { TypeNameHandling = TypeNameHandling.All });
            }
            else
            {
                Data = (object)info.GetValue("Data", typeof(object));
            }
            Name = (string)info.GetValue("Name", typeof(string)); // Serialize your other properties as needed.
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (context.Context is JsonStreamingContext)
            {
                info.AddValue("Data", JObject.FromObject(DataWrapper, new JsonSerializer { TypeNameHandling = TypeNameHandling.All }));
            }
            else
            {
                info.AddValue("Data", Data);
            }
            info.AddValue("Name", Name); // Deserialize your other properties as needed.
        }
    
        // Rest as in first update.
    }
