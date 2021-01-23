        internal class MyEventListener : EventListener
        {
            protected override void OnEventSourceCreated(EventSource eventSource)
            {
                base.OnEventSourceCreated(eventSource);
         
                Debug.WriteLine("Listener attached to the source");
            }
         
            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                ICollection readOnlyCollectionObject = (ICollection)eventData.Payload;
                object[] payload = new ArrayList(readOnlyCollectionObject).ToArray();
    
                Debug.WriteLine(eventData.Message, payload);
            }
        }
