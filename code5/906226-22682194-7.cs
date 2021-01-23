    public void RegisterMessageA(object target)
    {
        GeneratedClass x = new GeneratedClass();
        x.target = target;
        Messenger.Default.Register(x.target, x.Method);
    }
    private class GeneratedClass
    {
        public object target;
        public void Method(Message msg)
        {
            Console.WriteLine(msg.Name + " received by A");
            var x = target;
        }
    }
