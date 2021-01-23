    public class ItemNode
    {
        public int AncestorId { get; set; }
        public virtual Item Ancestor { get; set; }
        public int OffspringId { get; set; }
        public virtual Item Offspring { get; set; }
        public int Separation { get; set; } // optional
    }
