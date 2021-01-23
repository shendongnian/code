    public class Agenda
    {
        public ItemWithID item {get; set;} 
    }
    
    
    Interface ItemWithID
    {
        long ID {get; set;}
    }
    
    class MasterItem : ItemWithID
    {
        public long ID {get; set;}
    }
    
    class item1:MasterItem { //properties and methods here }
    
    class item2:MasterItem { //properties and methods here }
