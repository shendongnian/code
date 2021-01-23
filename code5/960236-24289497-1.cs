    class hotel
    {
        public string Name { get; set; }
        //other properties omitted for brevity 
        public List<Room> Rooms { get; set; }
    }
    class Room
    {
        public string Name { get; set; }
        //other properties omitted for brevity 
        public List<RoomType> RoomTypes { get; set; }
    }
    class RoomType
    {
        public string Name { get; set; }
        //other properties omitted for brevity 
        public List<Price> Prices { get; set; }
    }
    class Price
    {
        public string Name { get; set; }
        //other properties omitted for brevity 
        public decimal TotalPrice { get; set; }
    }
