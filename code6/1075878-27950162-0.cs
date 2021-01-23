    [DataContract]
    public class Menu
    {
        [DataMember]
        private List<Item> Items = new List<Item>();
    }
    
    [DataContract]
    public class Item
    {
        [DataMember]
        public int Id { get; set; }
    
        [DataMember]
        public int Level { get; set; }
    
        [DataMember]
        public string Title { get; set; }
    
        [DataMember]
        public string NavigateUrl { get; set; }
    
        [DataMember]
        public Menu Child { get; set; }
    }
