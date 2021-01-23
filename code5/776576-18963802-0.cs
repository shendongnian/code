    public class Hotel
    {
        public Hotel()
        {
            Rooms = new List<Room>();
        }
    
        public List<Room> Rooms { get; private set; }
        public string Name { get; private set; }
    
        public Hotel WithName(string name)
        {
            Name = name;
            return this;
        }
        
        public Hotel AddRoom(string name)
        {
            Rooms.Add(new Room { Name = name });
            return this;
        }
    }
    
    public class Room
    {
        public string Name { get; set; }
    }
