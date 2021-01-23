    public void OnConnection(object application, ext_ConnectMode 
      connectMode, object addInInst, ref Array custom)
    {
        _applicationObject = (DTE2)application;
        _addInInstance = (AddIn)addInInst;
        createProjectsFromTemplates(_applicationObject);
    }
