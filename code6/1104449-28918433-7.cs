    [DataContract]
    public partial class SyncablePackage 
    {
        [IgnoreDataMember]
        public object Data;
        [DataMember(Name="Data")]
        [JsonProperty("Data", TypeNameHandling = TypeNameHandling.All)] // REQUIRE output of type information.
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
