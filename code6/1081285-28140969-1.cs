    Dim timerDelegate As TimerCallback = AddressOf MoveFunct
    Dim autoEvent As New AutoResetEvent(True)
    Dim dt As System.Threading.Timer
    Private Sub toggle_MouseEnter(sender As Object, e As MouseEventArgs) Handles toggle.MouseEnter
        dt = New System.Threading.Timer(timerDelegate, autoEvent, 0, 1)
    End Sub
    Private Sub MoveFunct()
        Deployment.Current.Dispatcher.BeginInvoke(Sub()
                                                      verticalTransform.Y += 3
                                                  End Sub)
    End Sub
    Private Sub toggle_MouseLeave(sender As Object, e As MouseEventArgs) Handles toggle.MouseLeave
        dt.Dispose()
    End Sub
