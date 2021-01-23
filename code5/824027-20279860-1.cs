    public class MyLEvent<T, M>
        where T : class
        where M : class, IManager
    {
        private M manager;
        public MyLEvent()
        {
            manager.Delete();
        }
    }
