    public interface IUserCoreMagagerWrite
    { 
        public void SetData(User user);
    }
    public interface IUserCoreManagerRead
    {
        public User GetData();
    }
    public interface IUserCoreManagerReadWrite : IUserCoreManagerRead, IUserCoreMagagerWrite
    { 
    }
    public class UserCoreManager : IUserCoreManagerReadWrite
    {
        public User GetData()
        {
            return new User("abbo");
        }
        public void SetData(User user)
        {
            //...
        }
    }
    public class Core
    {
        public IUserCoreManagerReadWrite UserCoreManager { get; set; }
    }
    public class AsyncCore
    {
        public IUserCoreManagerRead UserCoreManager { get; set; }
    }
    public class TheProgram
    {
        public void SynchronousWork()
        {
            Core core = new Core();
            User user = core.UserCoreManager.GetData();
            core.UserCoreManager.SetData(user);
        }
        public void AsyncWork()
        {
            AsyncCore core = new AsyncCore();
            User user = core.UserCoreManager.GetData();
        }
    }
