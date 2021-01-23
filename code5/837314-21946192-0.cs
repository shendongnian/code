    using System.ComponentModel.Composition;
    using Microsoft.VisualStudio.TestWindow.Extensibility;
    using Microsoft.VisualStudio.ComponentModelHost;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.TestTools.Execution;
    
    public void OnConnection(object application, Extensibility.ext_ConnectMode connectMode, object addInInst, ref Array custom)
    {            
        Microsoft.VisualStudio.OLE.Interop.IServiceProvider InteropServiceProvider = application as Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
        _ServiceProvider = new ServiceProvider(InteropServiceProvider);
        _ComponentModel = (IComponentModel)_ServiceProvider.GetService(typeof(SComponentModel));
        _OperationState = _ComponentModel.GetService<IOperationState>();
        _OperationState.StateChanged += _OperationState_StateChanged;
    }
    
    void _OperationState_StateChanged(object sender, OperationStateChangedEventArgs e)
    {            
    }
