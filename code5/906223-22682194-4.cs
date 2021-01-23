    public void RegisterMessageB(object target)
    {
        Messenger.Default.Register(target, RegisterMessageB_Lambda);
    }
    private static void RegisterMessageB_Lambda(Message msg)
    {
        Console.WriteLine(msg.Name + " received by B");
    }
