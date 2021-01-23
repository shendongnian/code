    public void RegisterMessageB(object target)
    {
        Messenger.Default.Register(target, (Message msg) =>
        {
            Console.WriteLine(msg.Name + " received by B");
        });
    }
