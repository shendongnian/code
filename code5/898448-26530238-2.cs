    public class MySamplePlugin : MyPluginBase
    {
        public override event EventHandler MyEvent;
        public MySamplePlugin()
        { }
        public override void TestEvent()
        {
            Console.WriteLine("[appdomain:{0}] TestEvent: setting up delayed event.", AppDomain.CurrentDomain.FriendlyName);
            System.Threading.Timer timer = new System.Threading.Timer((x) => {
                Console.WriteLine("[appdomain:{0}] TestEvent: firing delayed event.", AppDomain.CurrentDomain.FriendlyName);
                if (MyEvent != null)
                    MyEvent(this, new EventArgs());            
            }, null, 1000, System.Threading.Timeout.Infinite);
        }
    }
