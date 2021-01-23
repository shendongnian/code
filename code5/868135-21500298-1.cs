    // When implementing Dispose, mark it my implementing 
    // IDisposable interface. It make you code more readable,
    // allow to put using(...) {...}  etc.
    class Foo: IDisposable {
      FileInfo File; // <- class, not struct
      Stream Stream; // <- class, not struct
     
      ...
    
      // Just useful thing, esp. while debugging
      public Boolean IsDisposed {
        get;
        private set;
      }
    
      // Since Foo is not a sealed class be ready that
      // it could be inherited: "protected virtual"
      protected virtual void Dispose(bool disposing) {
        // .Net often let you call Dispose many time, inc. on disposed instances; 
        // The same should do we
        if (IsDisposed)
          return;
    
        // You can access classes (not structs) in "if (disposing) {...}" only
        if (disposing) {
          if (!Object.ReferenceEquals(null, Stream))
            Stream.Dispose();
    
          if (!Object.ReferenceEquals(null, File))    
            File.Delete(); 
        }
    
        IsDisposed = true;
      }
    
      // MS recommendation
      public void Dispose() {
        Dispose(false);
        GC.SuppressFinalize(this);
      }
    
      // No finalizer here: finalizer just make you potential error
      // (resourse leak or Access Violation) unstable and so harder
      // to detect and correct.
    }
