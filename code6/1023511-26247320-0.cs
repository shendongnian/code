    public class MyBarcodeReader
    {
        private readonly SynchronizationContext syncContext;
        // Handler for barcode object's Readed event.
        private void Barcode.Readed(Object sender, Event e)
        {
            // Block the worker thread to synchronize with the thread associated
            // with SynchronizationContext.
            syncContext.Send(SyncMyEvent, (Object)e);
        }
        // Raises MyEvent on the thread associated with SynchronizationContext,
        // usually a UI thread.
        private void SyncMyEvent(Object o)
        {
            if (MyEvent != null)
            {
                MyEvent((Event)o);
            }
        }
        // Constructor.
        public MyBarcodeReader()
        {
            syncContext = SynchronizationContext.Current;
        }
    }
