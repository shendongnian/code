    class House
    {
        List<Room> Rooms { get; set; }
        string Name { get; set; }
        public City City { get; set; }
     }
    class Room
    {
        string Name { get; set; }
        public House House { get; set; }
    }
