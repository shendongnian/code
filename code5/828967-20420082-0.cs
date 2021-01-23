    public class RegisterPrintKey : IDisposable {
      ...
    
    // This class can allocate the Window Handle resource (HWND)
    private class HotKeyWndProc : NativeWindow {
    }
    
    // Explicit resource (HWND) allocation
    private HotKeyWndProc m_HotKeyWnd = new HotKeyWndProc();
    
    // I'd rather make a property from your "hasDisposed" field:
    //   - it's make easier to check instance's state (esp. while debugging)
    //   - IsDisposed is more popular name for this
    public Boolean IsDisposed {
      get;
      protected set; // <- or even "private set"
    }
    
    protected virtual void Dispose(Boolean dispose) {
      if (IsDisposed)
        return;
    
      if (disposed) {
        // Release any Objects here
    
        // You've allocated the HWND resource so you have to dispose it: 
        m_HotKeyWnd.DestroyHandle(); // <- Free HWND you've created
      }
    
      // Here, you may work with structures only!
    
      // You don't need these assignments, but you can safely do them:
      // mayhaps, they'll be useful for you while debugging 
      m_WindowHandle = IntPtr.Zero; 
      m_Keys = null; 
      m_ModKey = null;
    
      // Finally, we've done with disposing the instance
      IsDisposed = true; 
    }
    
    public void Dispose() {
      Dispose(true);
      // We've done with Dispose: "GC, please don't bother the disposed instance"
      GC.SuppressFinalize(this);
    }
    
    // A treacherous enemy I've commented out: 
    // if you've made a error in Dispose() it'll be resource leak 
    // or something like AccessViolation. The only good thing is that
    // you can easy reproduce (and fix) the problem.
    // If you've uncommented ~RegisterPrintKey() this leak/EAV will become
    // floating error: it'll appear and disappear on different workstations
    // OSs etc: you can't control GC when to run. Floating error is
    // much harder to detect.
     
    //~RegisterPrintKey() {
    // Dispose(false);
    // }
    }
