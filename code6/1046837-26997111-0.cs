    private static void MyMethod(object sender, EventArgs e)
    {
        var methods = new Dictionary<Type, Action<EventArgs>>();
        methods.Add(typeof(EventArgs), args => Console.WriteLine("Simple event args: " + args));
        methods.Add(typeof(MyEventArgs), args => Console.WriteLine("My event args: " + args));
        Action<EventArgs> desiredMethod;
        if (!methods.TryGetValue(e.GetType(), out desiredMethod))
        {
            desiredMethod = args => Console.WriteLine(String.Format("Unknown event args ({0}): {1}", args.GetType(), args));
        }
        desiredMethod(e);
    }
