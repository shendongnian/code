    internal class MyEventListener : EventListener
    {
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            base.OnEventSourceCreated(eventSource);
     
            Debug.WriteLine("Listener attached to the source");
        }
     
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            Debug.WriteLine("Event data: {0}", eventData.Payload[0]);
        }
    }
