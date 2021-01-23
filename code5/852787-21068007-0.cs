    class Room
    {
        House House { get; set; }
        string Name { get; set; }
    }
    class House
    {
        List<Room> Rooms { get; set; }
        string Name { get; set; }
        City City { get; set; }
    }
