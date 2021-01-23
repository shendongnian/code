    class Poco
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Purpose { get; set; }
        
        private Poco() {}
    
        public static Poco CreatePoco()
        {
            var poco = new Poco();
            new PropertyEmptySetter<POCO>(poco);
            return poco;
        }
    }
