    class Item
    {
        [Key]
        public int ID { get; set; }
    
        public string Name { get; set; }
        public int ListID { get; set; }
    
        [ForeignKey("ListID")]
        public virtual List List { get; set; }        
    }
