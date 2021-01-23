    public class House
    {
        public readonly ComponentCollection<Room> Rooms = new ComponentCollection<Room>();
    }
    public class Room : NamedObject
    {
        public readonly ComponentCollection<Door> Doors = new ComponentCollection<Door>();
    }
    public class Door : NamedObject
    {
        public readonly ComponentCollection<Window> Windows = new ComponentCollection<Window>();
    }
    public class Window : NamedObject
    {
    }
