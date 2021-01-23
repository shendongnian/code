       public class BookingHotel : IntBaseEntity            
    	{    
    		public string BookingName { get; set; }    
    		public string BookingReference { get; set; }    
    		public DateTime? CheckInDate { get; set; }    
    		public DateTime? CheckOutDate { get; set; }    
    		public int HotelId { get; set; }    
    		[ScriptIgnore]    
    		public Hotel Hotel { get; set; }        
         }         
