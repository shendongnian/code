    System.ArgumentNullException: Value cannot be null.
    Parameter name: window
       at System.Windows.Interop.WindowInteropHelper..ctor(Window window)
       at System.Windows.MessageBox.Show(Window owner, String messageBoxText, String caption, MessageBoxButton button, MessageBoxImage icon)
       at SAPBusinessObjects.WPF.Viewer.ViewerCore.HandleExceptionEvent(Object eventSource, Exception e, Boolean suppressMessage)
       at SAPBusinessObjects.WPF.Viewer.MainReportDocument.Export(ExportRequestContext context, String filePath)
       at SAPBusinessObjects.WPF.Viewer.ReportAlbum.<>c__DisplayClass4.<ExportReport>b__3()
       at SAPBusinessObjects.WPF.Viewer.DelegateMarshaler.<>c__DisplayClass29.<QueueOnThreadPoolThread>b__28(Object )
       at System.Threading.QueueUserWorkItemCallback.WaitCallback_Context(Object state)
       at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
       at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
       at System.Threading.QueueUserWorkItemCallback.System.Threading.IThreadPoolWorkItem.ExecuteWorkItem()
       at System.Threading.ThreadPoolWorkQueue.Dispatch()
       at System.Threading._ThreadPoolWaitCallback.PerformWaitCallback()
