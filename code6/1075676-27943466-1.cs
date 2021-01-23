    private DocumentEvents _documentEvents;
    public void OnConnection(object application,
                             ext_ConnectMode connectMode,
                             object addInInst,
                             ref Array custom)
    {
        _applicationObject = (DTE2)application;
        _addInInstance = (AddIn)addInInst;
        _documentEvents = _applicationObject.Events.DocumentEvents;
        _documentEvents.DocumentSaved += DocumentEvents_DocumentSaved;
                
    }
    
    public void OnDisconnection(ext_DisconnectMode disconnectMode,
                                ref Array custom)
    {
        _documentEvents.DocumentSaved -= DocumentEvents_DocumentSaved;
    }
