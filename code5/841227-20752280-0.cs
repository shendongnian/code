    public class Dummy
    {
        Thread T = new Thread(new ThreadStart(Listen));
        T.IsBackground = true;
        T.Start();
        ...
    }
