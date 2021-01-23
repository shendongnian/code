    public static class ListRoomExtender
    {
        public static void Add(this List<Room> rooms, string name, string description)
        {
            rooms.Add(new Room { Name = name, Description = description });
        }
    }
