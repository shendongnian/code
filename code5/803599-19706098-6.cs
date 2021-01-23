    public class MyState
    {
       public Timer { get; set; }
    }
    //create empty state
    MyState s = new MyState();
    //create timer paused
    Timer t = new Timer(MyCallback, s, Timeout.Infinite, Timeout.Infinite);
    //update state
    s.Timer = t;
    //now safe to start timer
    t.Change(..)
