    public class Header
    {
        public virtual int Id1 { get; set; }
        public virtual int Id2 { get; set; }
        public virtual string Something { get; set; }
        public virtual ICollection<HeaderVersion> Versions { get; set; }
    }
