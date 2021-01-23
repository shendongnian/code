    public abstract class FlaggableBase<T>
    {
        public abstract T Id { get; internal set; }
        public abstract Tally Tally { get; internal set; }
        public abstract Guid? TallyId { get; internal set; }
    }
