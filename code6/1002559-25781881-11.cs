    public class TestFlaggable : FlaggableBase<Guid>
    {
        public override Guid Id { get; internal set; }
        public override Tally Tally { get; internal set; }
        public override Guid? TallyId { get; internal set; }
    }
    public class Tally
    {
        public Guid Id { get; internal set; }
        public FlaggableBase<Guid> Subject { get; internal set; }
        public ICollection<Flag> Flags { get; internal set; }
    }
    public class Flag
    {
        public Guid Id { get; internal set; }
        [Required]
        public Tally Tally { get; internal set; }
        public Guid TallyId { get; internal set; }
        public Guid CreatorId { get; internal set; }
    }
