    if (roomNumber > 0 && !string.IsNullOrWhitespace(roomType))
    {
        HotelRoom h = new HotelRoom(roomNumber, roomType);
        hotelRooms.Add(h);
    }
    else
    {
        // return the variables to the ui, so that the user can do another 
        // selection if something is missing or wrong.
    }
