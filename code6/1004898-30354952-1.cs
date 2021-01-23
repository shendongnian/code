    var roomBookings = new List<RoomBooking>();
    roomBookings.Add(new RoomBooking()
    {
        Id = 1,
        BookingType = BookingType.PartyOrder,
        Date = new DateTime(2014, 11, 15),
        PartyRoomId = 2,
        TimeSlotId = 1,
        PartyRoom = new PartyRoom {
            Bookings = roomBookings
        }
    });
    roomBookings.Add(new RoomBooking()
    {
        Id = 2,
        BookingType = BookingType.PartyOrder,
        Date = new DateTime(2014, 11, 15),
        PartyRoomId = 4,
        TimeSlotId = 3,
        PartyRoom = new PartyRoom {
            Bookings = roomBookings
        }
    });
    roomBookings.Add(new RoomBooking()
    {
        Id = 3,
        BookingType = BookingType.PartyOrder,
        Date = new DateTime(2014, 11, 15),
        PartyRoomId = 5,
        TimeSlotId = 4,
        PartyRoom = new PartyRoom {
            Bookings = roomBookings
        }
    });
