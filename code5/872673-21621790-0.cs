    public void Close() { 
      if (!IsOpen) return;
      
      try { 
        CloseCore();
      }
      finally { 
        Dispose();
        RaiseClosed();
      }
    }
    
    protected virtual void CloseCore()
    {
      // Derived types override this to customize their close
      // behavior 
    }
