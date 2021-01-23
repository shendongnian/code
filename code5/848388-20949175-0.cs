    Public Class Class1
        Public Event TestEvent()
    
        Public Sub RaiseTestEvent()
            RaiseEvent TestEvent()
        End Sub
    End Class
