    public class MyState
    {
       public Timer{get;set;}
    }
    MyState s = new MyState();
    Timer t = new Timer(MyCallback, s, Timeout.Infinite, Timeout.Infinite);
    s.Timer = t;
    //now safe to start timer
    t.Change(..)
