    Private cTimer As New System.Timers.Timer
    Private Sub inittimer()
        cTimer.AutoReset = True
        cTimer.Interval = 1000
        AddHandler cTimer.Elapsed, AddressOf cTimerTick
        cTimer.Enabled = True
    End Sub
    
    Private Sub cTimerTick()
        If cTimer.AutoReset = True Then
           'do your code if not paused by autoreset false
        End If
    End Sub
