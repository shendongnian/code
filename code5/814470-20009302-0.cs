    class User : IdentityUser // so it has public string Id!
    {
        public virtual Item Item { get; set; }
    }
    
    class Item
    {
        public string Id { get; set;}
        public virtual User User { get; set; }
    }
