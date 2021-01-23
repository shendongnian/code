    internal String ScannedValue {
        get { return _scannedValue; }
        set {
            _scannedValue = value;
            ThreadPool.QueueUserWorkItem( (WaitCallback) delegate {
                target = new object(); // query database
                if (ChangedScannedValue != null) ChangedScannedValue(_scannedValue);
            } );
        }
    }
