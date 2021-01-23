    class GroupedHorses
    {
        public string Color { get; set; }
        public IList<HorseShape> Horses { get; set; }
    }
    class HorseShape
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
    // Define other methods and classes here
    class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string UninterestingProperty { get; set; }
    }
