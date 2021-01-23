    public interface IWrapUserManager
    {
        UserManager WrappedUserManager {get; set;}
        //provide methods / properties that wrap up all UserManager methods / props.
    }
    public class WrapUserManager : IWrapUserManager
    {
        UserManager WrappedUserManager {get; set;}
        //implementation here. to test UserManager, just wrap all methods / props.
    }
    //Here's a class that's actually going to use it.
    public class ClassToTest
    {
        private IWrapUserManager _manager;
        public ClassToTest(IWrapUserManager manager)
        {
            _manager = manager;
        }
        //more implementation here
    }
