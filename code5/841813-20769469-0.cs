    public class EventManager
    {
        public delegate void TempDelegate();
        public static event TempDelegate eSomeEvent;
    
        // Not thread safe as well as your code
        // May be internal, not public is better (if SomeOtherClass is in the same namespace) 
        public static void PerformSomeEvent() {
          if (!Object.ReferenceEquals(null, eSomeEvent)) 
            eSomeEvent(); // <- You can do it here
        }
    }
    
    public class SomeOtherClass
    {
        //doing some stuff, then:
        EventManager.PerformSomeEvent();
    }
