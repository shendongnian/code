    public class Blah : MarshalByRefObject
    {
        public event MyEventHandler OnEvent;
        public void EventHandler()
        {
            if(OnEvent != null) { OnEvent(); }
        }
    }
