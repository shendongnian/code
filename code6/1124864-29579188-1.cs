    [DataContract]
    public class Item
    {
        //...
        [DataMember]
        public virtual ICollection<ItemImage> Images { get; set; }
    }
