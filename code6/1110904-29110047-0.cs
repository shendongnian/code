    public class House
    {
        private readonly List<Room> _rooms = new List<Room>();
        public Room Rooms(string roomName)
        {
            return _rooms.Single(x => x.Name == roomName);
        }
        public void AddRoom(string roomName)
        {
            _rooms.Add(new Room { Name = roomName });
        }
    }
    public class Room
    {
        private readonly List<Door> _doors = new List<Door>();
        public string Name { get; set; }
        public Door Doors(string doorName)
        {
            return _doors.Single(x => x.Name == doorName);
        }
        public void AddDoor(string doorName)
        {
            _doors.Add(new Door { Name = doorName });
        }
    }
    public class Door
    {
        private readonly List<Window> _windows = new List<Window>();
        public string Name { get; set; }
        public Window Windows(string windowName)
        {
            return _windows.Single(x => x.Name == windowName);
        }
        public void PlaceWindow(string windowName)
        {
            _windows .Add(new Window { Name = windowName }); 
        }
    }
    public class Window
    {
        public string Name { get; set; }
    }
