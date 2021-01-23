    private static Dictionary<Type, Action<EventArgs>> _EventDispatcher;
    static Program()
    {
        _EventDispatcher = new Dictionary<Type, Action<EventArgs>>();
        _EventDispatcher.Add(typeof(EventArgs), OnEventArgs);
        _EventDispatcher.Add(typeof(MyEventArgs), OnMyEventArgs);
    }
    private static void MyMethod(object sender, EventArgs e)
    {
        Action<EventArgs> eventMethod;
        if (!_EventDispatcher.TryGetValue(e.GetType(), out eventMethod))
            eventMethod = OnUnknownEventArgs;
        eventMethod(e);
    }
    private static void OnEventArgs(EventArgs e)
    {
        Console.WriteLine("Simple event args: " + e);
    }
    private static void OnMyEventArgs(EventArgs e)
    {
        var myEventArgs = (MyEventArgs)e;
        Console.WriteLine("My event args: " + myEventArgs);
    }
    private static void OnUnknownEventArgs(EventArgs e)
    {
        Console.WriteLine(String.Format("Unknown event args ({0}): {1}", e.GetType(), e);
    }
    private static void Main(string[] args)
    {
        MyMethod(null, new EventArgs());
        MyMethod(null, new MyEventArgs());
        MyMethod(null, new AnotherEventArgs());
        Console.ReadKey();
    }
