    public interface IFlaggable<out T>
    {
        T Id { get; }
        Tally Tally { get; }
        Guid? TallyId { get; }
    }
