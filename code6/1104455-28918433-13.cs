    [DataContract]
    [Serializable]
    public partial class SyncablePackage : ISerializable
    {
        public SyncablePackage() { }
        public SyncablePackage(SerializationInfo info, StreamingContext ctxt)
        {
            var jObj = (JObject)info.GetValue("Data", typeof(JObject));
            if (jObj != null)
                DataWrapper = jObj.ToObject<object>(new JsonSerializer { TypeNameHandling = TypeNameHandling.All });
            Name = (string)info.GetValue("Name", typeof(string)); // Serialize your other properties as needed.
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Data", JObject.FromObject(DataWrapper, new JsonSerializer { TypeNameHandling = TypeNameHandling.All }));
            info.AddValue("Name", Name); // Deserialize your other properties as needed.
        }
        [IgnoreDataMember]
        public object Data;
        [DataMember(Name = "Data")]
        object DataWrapper
        {
            get
            {
                if (Data == null)
                    return null;
                return JsonTypeWrapper.CreateWrapper(Data);
            }
            set
            {
                var wrapper = value as JsonTypeWrapper;
                if (wrapper == null)
                {
                    if (value != null)
                        Debug.WriteLine("Invalid incoming data type: " + value.ToString());
                    Data = null;
                    return;
                }
                Data = wrapper.ObjectValue;
            }
        }
    }
