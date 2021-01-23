    protected override void Dispose(bool isDisposing){
     if(isDisposing && !IsDisposed){
      //Release all resources and mutex here
      IsDisposed = true;
     }
     base.Dispose(isDisposing);
    }
