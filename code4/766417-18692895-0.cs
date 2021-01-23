    Protected Overrides Sub OnOwnerInitialized()
        If Not MobileApplication.Current.Dispatcher.CheckAccess() Then
            MobileApplication.Current.Dispatcher.BeginInvoke(DirectCast(Function() DoSomethingWrapper(), System.Threading.ThreadStart))
            Return
        End If
    End If
            
            
    Private Function DoSomethingWrapper() As Boolean
        DoSomething()
        Return True ' dummy value to satisfy that this is a function
    End If
