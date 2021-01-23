    abstract class DatabaseEntryBase
    {
        public DatabaseEntryBase()
        {
            // You can initialize properties here
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
        
        var newEntry = new FirstEntry(); 
        newEntry.ModifiedTime = [actual time here];
        newEntry.IsDeleted = false;
    }
    
