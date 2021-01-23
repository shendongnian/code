    public class Furni
    {
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual List<Room> Rooms { get; set; }  // if you want to have the relationship both ways
    }
