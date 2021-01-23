    public class ViewModel
    {
        public static object lockObject = new Object();
    }
    lock(Model.lockObject)
    {
       // do something...
    }
