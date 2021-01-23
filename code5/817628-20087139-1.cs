    public class SpecialRoom : Room
    {
        public SpecialRoom() { }
        public SpecialRoom(Room copy)
        {
            this.NumberOfDoors = copy.NumberOfDoors;
            this.NumberOfWindows = copy.NumberOfWindows;
        }
        public int NumberOfJacuzzis { get; set; }
    }
