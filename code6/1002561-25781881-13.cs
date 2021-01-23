    public class Tally
    {
        public Guid Id { get; internal set; }
        public IFlaggable<Guid> Subject { get; internal set; }
        public ICollection<Flag> Flags { get; internal set; }
    }
