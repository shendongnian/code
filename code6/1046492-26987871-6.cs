    namespace EventSample
    {
        public delegate void AfterChildEventHandler(Control control, Keys key);
        public class GlobalEvent
        {
            public static event AfterChildEventHandler OnChildEventFire;
    
            public static void Invoke(Control control, Keys key)
            {
                if (OnChildEventFire != null)
                    OnChildEventFire(control, key);
            }
        }
    }
