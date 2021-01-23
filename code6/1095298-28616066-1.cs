    [DataContract]
    public class Package<T>
    {
        [DataMember]
        public T PackagedItem { get; set; }
    }
