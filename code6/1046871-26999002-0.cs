    Public Class MyClass
        Dim NextValidTime as DateTime
    
        public sub Some_Event_Handler()
            If Now() > NextValidtime Then
                'do stuff
                NextValidTime = DateAdd(DateInterval.Second, 1, Now)
            Else
                ' Not enough time has passed - do nothing
            End If
        end sub
    End Class
