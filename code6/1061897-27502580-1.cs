    [JsonObject(MemberSerialization.OptIn)]
    public class LinkDataViewModelWrapper
    {
       [JsonProperty("PostPropertyRequest")]
        public LinkDataViewModel LinkDataViewObj{ get; set; }
    }
