    public class Downstairs : Floor
    {
        public IList<Room> Rooms { get; set;}
    }
    public class Upstairs : Floor
    {
        public IList<Room> Rooms { get;set; }
    }
    public class House
    {
        public HouseOwner Owner { get;set; }
        public readonly IList<Floor> Floors { get; private set;}
        public House(HouseOwner owner, IList<Floor> floors)
        {
            this.Owner = owner;
            this.Floors = floors;
        }
        public void AddFloor(Floor floor)
        {
            this.Floors.Add(floor);
        }
        public int TotalFloors()
        {
            return this.Floors.Count();
        }
    }
