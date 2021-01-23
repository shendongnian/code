    public class Dummy
    {
        public void Test()
        {
            Thread T = new Thread(new ThreadStart(Listen));
            T.IsBackground = true;
            T.Start();
        }
        ...
    }
