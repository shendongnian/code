     //your custom parameters class
        public class MyCustomParameters
        {
            //whatever you want here...
        }
    
        //the event trigger
        public class EventTrigger
        {
            //declaration of the delegate type
            public delegate void AccelerationDelegate(MyCustomParameters parameters);
    
            //declaration of the event
            public event AccelerationDelegate Accelerate;
    
            //the method you call to trigger the event
            private void OnAccelerate(MyCustomParameters parameters)
            {
                //actual triggering of the events
                if (Accelerate != null)
                    Accelerate(parameters);
            }
        }
        
        //the listener
        public class Listener
        {
            public Listener(EventTrigger trigger)
            {
                //the long way to subscribe to the event (to understand you create a delegate)
                trigger.Accelerate += new EventTrigger.AccelerationDelegate(trigger_Accelerate);
    
                //a shorter way to subscribe to the event which is equivalent to the statement above
                trigger.Accelerate += trigger_Accelerate;
            }
    
            void trigger_Accelerate(MyCustomParameters parameters)
            {
                //implement event handling here
            }
        }
