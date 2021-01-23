    //Call on OnClosing or OnExit or similar context
    protected override void Dispose(bool isDisposing)
    {
            
            if(isDisposing && !_isDisposed){
             if(disposeableImage != null){
               disposeableImage.Dispose();
               disposeableImage = null;
             }
            }
    }
