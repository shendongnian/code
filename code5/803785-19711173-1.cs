    public class Room
    {
        public string url { get; set; }
        public double price { get; set; }
        public string room_code { get; set; }
    }
    
    public class Hotel
    {
        public int hotel_id { get; set; }
        public Dictionary<string, Room> room_types { get; set; }
    }
    
    public class RootObject
    {
        public int api_version { get; set; }
        public List<int> hotel_ids { get; set; }
        public List<Hotel> hotels { get; set; }
    }
