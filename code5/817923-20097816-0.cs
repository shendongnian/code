    class Dto
    {
        public long PrimaryKey { get; set; }
        public int Id { get; set; }
        public int Fk_Id { get; set; }
        public Single? Price { get; set; }
    }
    
    class Entity
    {
        public long PrimaryKey { get; set; }
        public int Id { get; set; }
            
        public Single? Price { get; set; }
    }
