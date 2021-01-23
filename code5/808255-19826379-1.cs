     public class Television
        {
            public int TelevisionID { get; set; }
            public int ModelID { get; set; }
    
            public virtual ICollection<Room> Rooms { get; set; }
        }
    
        public class Room
        {
            public int RoomID { get; set; }
            //
            public virtual ICollection<Television> Televisions { get; set; }
    
        }
    
        public class TelevisionRoom
        {
            public int TelevisionID { get; set; }
            public int RoomID { get; set; }
            public int Quantity { get; set; }
        }
        
        public class Model
        {
            public int ModelID { get; set; }
            public string ModelName { get; set; }
        }
