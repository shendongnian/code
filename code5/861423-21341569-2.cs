         ICOMCallbackContainer ICOMCallbackTestServer.CallbackContainer
        {
            get { return _callbackContainer; }
            set { 
                if (_callbackContainer != null)
                {
                      Marshal.ReleaseComObject(_callbackContainer); // calls IUnknown.Release()
                      _callbackContainer = null;
                }
                _callbackContainer = value;
            }
        }
