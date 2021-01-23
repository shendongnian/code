    public class SampleClass : ISampleEvents
    {
        public event SampleDelegate SampleEvent;
    
        public void Invoke()
        {
            if (SampleEvent != null) // check if handlers attached
               SampleEvent(); // raise event
        }
    }
