    public interface IUserContext {
        User CurrentUser { get; }
    }
    public interface ITimeProvider {
        DateTime Now { get; }
    }
