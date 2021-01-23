    public abstract class UserDisplayBase<T> : IUserDisplayBase<T>
        where T : UserBase
    {
        public T User { get; protected set; }
    }
    public interface IUserDisplayBase<out T>
        where T : UserBase
    {
        T User { get; }
    }
    private static void DoThingsWithUserDisplay<TDisplay>(TDisplay userDisplay)
        where TDisplay : IUserDisplayBase<UserBase>
    {
        userDisplay.User.DoSomethingWithUser();
    }
