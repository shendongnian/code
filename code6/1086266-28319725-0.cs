    public class LaceHasCard
    {
        public virtual int Id { get; set; } // the key
        public virtual Card Card { get; set; }
        public virtual Lace Lace { get; set; }
    }
