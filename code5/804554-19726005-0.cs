    public class ta_Hotel2
    {
        public int hotel_id { get; set; }
        public Dictionary<string, ta_Room> room_types { get; set; }
    
        public ta_Hotel2()
        {
           room_types = new Dictionary<string, ta_Room>();
        }
    }
