    public interface ITimeProvider
    {
        DateTime Now { get; }
    }
    
    public class TimeProvider : ITimeProvider
    {
        DateTime Now { get { return DateTime.Now ; } }
    }
