    public class MyDataClass
    {
        public ObjectId _id { get; set; }
        public string Somedata { get; set; }
        public Object1 object1 { get; set; }
    }
    
    public class Object1
    {
        public string name { get; set; }
        public Object2 object2 { get; set; }
    }
    
    public class Object2
    {
        public string Text { get; set; }
    }
