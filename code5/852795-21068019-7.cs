    class House 
    {
         public void AddRoom(Room room)
         {
            room.House = this;
            if (Rooms == null)
                Rooms = new List<Room>();
            Rooms.Add(room);
         }
    }
