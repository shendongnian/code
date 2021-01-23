        public class Rootobject
        {
            public int api_version { get; set; }
            public int[] hotel_ids { get; set; }
            public int num_hotels { get; set; }
            public Hotel[] hotels { get; set; }
        }
        public class Hotel
        {
            public int hotel_id { get; set; }
            public Room_Types room_types { get; set; }
        }
        public class Room_Types
        {
            public FenwayRoom FenwayRoom { get; set; }
        }
        public class FenwayRoom
        {
            public string url { get; set; }
            public int price { get; set; }
            public int fees { get; set; }
            public int fees_at_checkout { get; set; }
            public int taxes { get; set; }
            public int taxes_at_checkout { get; set; }
            public int final_price { get; set; }
        }
    }
