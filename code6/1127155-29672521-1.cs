    public class MyArgs1 : EventArgs
    {
        public string Value1;
    }
    public class MyEventSource
    {
        public event EventHandler<MyArgs1> Args1Event;
        public EventInfo GetEventInfo()
        {
            return this.GetType().GetEvent("Args1Event");
        }
        public void FireOne()
        {
            if (Args1Event != null)
                Args1Event(this, new MyArgs1() { Value1 = "Bla " });
        }
    }
    class Program
    {
        public static void Main(params string[] args)
        {
            var myEventSource = new MyEventSource();
            using (var handlerRegistry = new EventHandlerRegistry())
            {
                handlerRegistry.RegisterHandlerFor(
                    myEventSource,
                    myEventSource.GetEventInfo(),
                    () => Console.WriteLine("Yo there's some kinda event goin on"));
                handlerRegistry.RegisterHandlerFor(
                    myEventSource,
                    myEventSource.GetEventInfo(),
                    () => Console.WriteLine("Yeah dawg let's check it out"));
                myEventSource.FireOne();
            }
            myEventSource.FireOne();
        }
    }
