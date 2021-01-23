    public class Downstairs : Floor
    {
        public IList<Room> Rooms { get; set;}
    }
    public class Upstairs : Floor
    {
        public IList<Room> Rooms { get;set; }
    }
    public class House
    {
        public HouseOwner Owner { get;set; }
        public readonly Downstairs Downstairs { get; private set;}
        public readonly Upstairs Upstairs { get; private set;}
        public House(HouseOwner owner, Downstairs downstairs, Upstairs upstairs)
        {
            this.Downstairs= downstairs;
            this.Upstairs = upstairs;
        }    
    }
