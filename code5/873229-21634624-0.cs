    public interface IUser
    {
        void SomeMethod();
    }
    public abstract class User : IUser
    {
        public abstract void SomeMethod();
    }
    public class AdminUser : User
    {
        public override void SomeMethod()
        {
            throw new NotImplementedException();
        }
    }
    public class NormalUser : User
    {
        public override void SomeMethod()
        {
            throw new NotImplementedException();
        }
    }
