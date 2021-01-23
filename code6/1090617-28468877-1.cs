    public class Obj1
    {
        [Key]
        public int ID { get; set;}
        public string name { get; set; }
    }
    public class Obj2
    {
        [Key]
        public int ID { get; set; }
        public int FromID { get; set; }
        public int ToID { get; set; }
        public int quantity { get; set; }
    }
