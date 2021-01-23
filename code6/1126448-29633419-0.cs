    // blocking collection
    private BlockingCollection<Bitmap> m_Queue = ...
    // camera thread
    while( run )
    {
        var bitmap = GrabFrame();
        m_Queue.Add( bitmap );
    }
    // worker thread
    try
    {        
        while( true )
        {
            // Take() will block if the queue is empty
            var bitmap = m_Queue.Take();
            bitmap.Save( ... );
            bitmap.Dispose();
        }
    catch( InvalidOperationException )
    {
         // you'll end up here if you call `m_Queue.CompleteAdding()`
         // (after the queue has been emptied, of course)
    }
