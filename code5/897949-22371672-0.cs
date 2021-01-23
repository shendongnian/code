    public interface IUserContext {
        User CurrentUser { get; }
        bool IsInRole(string role);
    }
    public interface ITimeProvider {
        DateTime Now { get; }
    }
