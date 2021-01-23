public class BaseClass {
    private Timer tmrWork;
    protected bool IsReady;
    public BaseClass() {
        // read values from config
        tmrWork = new Timer(tmrWork_Tick, null, 1, SomeInterval);
    }
    private void tmrWork_Tick(object state)
    {
        if (IsReady)
            DoWork();
    } 
    protected abstract void DoWork();
}
public class ChildClass: BaseClass {
    public ChildClass() {
        // do a bunch of stuff here
        // potentially time consuming
        IsReady = true;
    }
    protected override void DoWork() {
        // do stuff
    }
}
