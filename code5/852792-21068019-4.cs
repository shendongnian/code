    class House 
    {
         public void AddRoom(Room room)
         {
            room.House = this;
            Rooms.Add(room);
         }
    }
