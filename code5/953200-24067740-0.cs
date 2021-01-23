    public class ClassWithEvent
    {
        public event Action<object, EventArgs> MyEvent;
    
        public ClassWithEvent() { }
    
        public void RegisterForEvent(Action<object, EventArgs> Method)
        {
            MyEvent += Method;
        }
    
        public void Trigger()
        {
            if(MyEvent != null)
            {
                MyEvent(this, null);
            }
        }
    
    }
    
    public class ClassToRegister
    {
        public ClassWithEvent MyEventClass = new ClassWithEvent();
    
        public ClassToRegister() { }
    
        public void RegisterMe()
        {
            MyEventClass.RegisterForEvent(MyEventMethod);
    
            MyEventClass.Trigger();
        }
    
        public void MyEventMethod(Object sender, EventArgs e)
        {
            Console.Writeline("Hello there!");
        }
    }
