    Protected Overrides Sub OnOwnerInitialized()
        If Not MobileApplication.Current.Dispatcher.CheckAccess() Then
            MobileApplication.Current.Dispatcher.BeginInvoke(AddressOf OnOwnerInitialized)
            Return
        End If
        
        DoSomething()
    End Sub
