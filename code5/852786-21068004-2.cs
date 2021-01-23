    class House
    {
        public House(City city)
        {
            City = city;
        }
        List<Room> Rooms { get; set; }
        string Name { get; set; }
        City City { get; set; }
    }
    class Room
    {
        public Room(House house)
        {
            House = house;
        }
        string Name { get; set; }
        House House { get; set; }
    }
