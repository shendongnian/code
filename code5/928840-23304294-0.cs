    Private WithEvents tim As New System.Timers.Timer
        Public Delegate Sub doSub()
        Private thingToDo As doSub
        Dim tt = New ToolTip()
    
        Public Sub TimeOut(d As doSub, milliseconds As Integer)
            thingToDo = d
            tim.AutoReset = False
            tim.Interval = milliseconds
            tim.Start()
        End Sub
    
        Private Sub tim_Elapsed(sender As Object, e As System.Timers.ElapsedEventArgs) Handles tim.Elapsed
            Invoke(thingToDo)
    
        End Sub
        Private Sub hide()
            picturebox.hide()
    
        End Sub
        Private Sub show()
            TimeOut(Address of hide, 5000)
    
        End Sub
