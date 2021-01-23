    public class SampleClass : ISampleEvents
    {
        public event SampleDelegate SampleEvent; // declare event
    
        public void Invoke()
        {
            if (SampleEvent != null) // check if handlers attached
               SampleEvent(); // raise event (i.e. invoke event delegate)
        }
    }
