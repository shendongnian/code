    public class Level
    {
        public IItem[] Item {get; set;}
        public IRoom[] Room {get; set;}
        public IMonster[] Monster {get; set;}
        ...
    }
    public class ItemBook: IItem
    {
        public string Name
        {
            set { /* this code will be automatically executed during deserialization */ }
        }
        public ItemBook()
        {
            /* and this code */ 
        }
    }
    ...
