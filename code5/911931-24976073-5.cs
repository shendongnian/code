    public class Object
    {
        // Alternatively, you can use a mapping class to define the primary key
        // I just wanted to make the example clear that this is the
        // surrogate primary key property.
        [Key]
        private int ObjectID { get; set; } // IIRC, you can make this private...
        public int Key1 { get; set; }
        public int Key2 { get; set; }
    }
