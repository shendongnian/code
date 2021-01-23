    abstract class DatabaseEntryBase
    {
        public DatabaseEntryBase()
        {
            // You can initialize properties to a default value here
            this.IsDeleted = false;
        }
    
        public DateTime ModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
    
    class Entry : DatabaseEntryBase
    {}
    
    static void Main()
    {
        //-- Do your SQL stuff --//
        
        var newEntry = new Entry(); 
        newEntry.ModifiedTime = DateTime.Now;
        newEntry.IsDeleted = false;
    }
    
