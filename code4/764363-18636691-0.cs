    public class Room
    {
        public int ID { get; set; }
        public virtual Furni Furniture { get; set; } // virtual is for lazy loading
    }
