    protected virtual void Dispose(bool pDisposing)
    {
        if(!_isDisposed)
        {
            if(pDisposing) //dispose managed
            {
                if(_cookie > 0 && _cp != null)
                {
                    _cp.Unadvise(_cookie);
                    _cookie = 0;
                }
                if (_cp != null)
                {
                    Marshal.ReleaseComObject(_cp);
                    _cp = null;    
                }
                if(_cpc != null)
                {
                    //needed due to the implicit queryinterface on cast 
                    //_cpc = (IConnectionPointContainer)_myObject;
                    Marshal.ReleaseComObject(_cpc);
                    _cpc = null;
                }
                if(_myObject != null)
                {
                    //you could test if Marshal.ReleaseComObject(_myObject) == 0
                    //If it's not, the IMyInterface cast is probably increasing the refcount.
                    //but use FinalRelease just to be safe.
                    Marshal.FinalReleaseComObject(_myObject);
                    _myObject = null;
                }
            }
            _isDisposed = true;
         }
     }
