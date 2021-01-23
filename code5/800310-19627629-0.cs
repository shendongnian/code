    public class Entity
    {
        public ObjectId Id { get; set; }
        public E2 e = new E2();
    }
    
    public class E2 : ISupportInitialize
    {
        [BsonIgnore]
        public int counter = 5;
        public DateTime last_update { get; set; }
    
        public void BeginInit()
        {
        }
    
        public void EndInit()
        {
            counter = ConfigClass.SomeStaticMethod();
        }
    }
