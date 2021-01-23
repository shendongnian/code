    using System.Collections.Concurrent;
    // somewhere in your code...
    static Action GetThreadStarter()
    {
        var queue = new ConcurrentQueue<Stuff>();
        return () => {
            new Thread(() => MyThreadFunc(queue)).Start();
        };
    }
    static Action ThreadStarter = GetThreadStarter();
    // use it:
    void Test() {
        foreach (...) {
            ThreadStarter();
        }
    }
