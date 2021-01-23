    class Pic
    { 
    public Pic()
    {
    Categories = new List();
    }
    
        public long PictureID { get; set; }
        public int UserID { get; set; }
        public string File { get; set; }
        public ICollection<Category> Categories{ get; set; }
        public DateTime Posted { get; set; }
    }
