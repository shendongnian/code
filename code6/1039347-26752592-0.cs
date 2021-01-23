    public class WrapperClass
    {
	    public ReservationStream ReservationStream { get; set; }
    }
    WrapperClass wrapperClass = serializer.Deserialize<WrapperClass>(strJSON);
   
