    public class Datum
    {
    }
    
    public class Items
    {
        public int count { get; set; }
        public List<Datum> data { get; set; }
    }
    
    public class RootObject
    {
        public Items items { get; set; }
    }
  
