    public void RegisterMessageA(object target)
    {
        Messenger.Default.Register(target, (Message msg) =>
        {
            Console.WriteLine(msg.Name + " received by A");
            var x = target;
        });
    }
