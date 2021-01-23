    public class Hotel
    {
        public Hotel(string hotelId){
             this.hotelId = hotelId;
             this.rooms = New List<Room>();
        }
    
        public string hotelId { get; private set; }
        public List<Room> rooms { get; private set; }           
    }
