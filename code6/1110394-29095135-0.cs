     public class myRecordEntryViewModel 
    {
        public  long ID { get; set; }
        public  string Name { get; set; }
        public string Department { get; set; }
        //public string[] ItemsList { get; set; }
        public List<Item> ItemsList {get ; set;}
    }
