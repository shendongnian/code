    [DataContract]
    public class ChainedListNodeOfString : ChainedListNode<string>
    {
        [DataMember]
        public string Value { get; set; }
    }
