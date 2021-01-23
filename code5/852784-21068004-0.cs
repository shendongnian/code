    class City
    {
        List<House> Houses { get; set; }
        string Name { get; set; }
    }
    
    class House
    {
        List<Room> Rooms { get; set; }
        string Name { get; set; }
        City City { get; set; }
    }
    
    class Room
    {
        string Name { get; set; }
        House House { get; set; }
    }
