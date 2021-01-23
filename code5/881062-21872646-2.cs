    public interface IDateRangeContext {
        DateTime Start { get; }
        DateTime End { get;
    }
    public interface IDateRangeContextWithSetter : IDateRangeContext {
        DateTime Start { get; set; }
        DateTime End { get; set; }
    }
