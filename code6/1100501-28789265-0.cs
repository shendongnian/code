    public class Test
    {
        //Other class
        public event Action<int, bool> MyEvent;
        //Helper
        public void AddAction(Action a, object cls, string eventName)
        {
            var eventVar = cls.GetType().GetEvent(eventName);
            //Need some code in here to wrap the action
            if (null != eventVar) 
            {
                eventVar.AddEventHandler(delegate (int i, bool condition) 
                {
                    a(i, condition);
                });
            }
        }
    }
