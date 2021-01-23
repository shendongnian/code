    public class Rootobject
    {
        public int api_version { get; set; }
        public List<int> hotel_ids { get; set; }
        public List<Hotel> hotels { get; set; }
    }
    public class Hotel
    {
        public int hotel_id { get; set; }
        public Room_Types room_types { get; set; }
    }
    public class Room_Types
    {
        public List<Room> Rooms { get; set; }
    }
    public class Room
    {
        public string Type { get; set; }
        public string Url { get; set; }
        public float Price { get; set; }
    }
