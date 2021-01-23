    public BookingItemResponse(BookingItem[] BookingItems,Currency="USD", string bookingName=null, string passengerEmail =null)
    {
      
        Request.BookingItem[]=BookingItems;
       
        //If the default value is null you can remove the ifs
        Request.BookingName=bookingName;
        Request.PassengerEmail=passengerEmail;
        //else you can use the ?? operator
        Request.BookingName=bookingName ?? "Your default value";
        Request.PassengerEmail=passengerEmail ?? "Your default value";
        return BookingItemResponse;
    }
