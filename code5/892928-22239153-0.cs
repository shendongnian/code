    while (SomethingIsTrue) // i'm presuming you have a loop like this already?)
    {
        bool gotLock = false;
        m_WrtblBtmp.Dispatcher.Invoke(() =>
        {
            Debug.WriteLine("About to try to lock Bitmap" + m_WrtblBtmp.GetHashCode().ToString());
            gotLock = m_WrtblBtmp.TryLock(SomeTimeoutConstant);                     
            Debug.WriteLine((gotLock ? "got lock on " : "DID NOT lock ") + m_WrtblBtmp.GetHashCode().ToString());
        });
        if (gotLock && ReadNextVideoFrame(m_VideoDecoder, m_BackBuffer))
        {
            m_WrtblBtmp.Dispatcher.Invoke(() => 
            {
                Debug.WriteLine("About to dirty up Bitmap" + m_WrtblBtmp.GetHashCode().ToString());
                m_WrtblBtmp.AddDirtyRect(new Int32Rect(0, 0, 1280, 1024));
                Debug.WriteLine("About to Unlock Bitmap" + m_WrtblBtmp.GetHashCode().ToString());
                m_WrtblBtmp.Unlock();
            });
        }
   }    
