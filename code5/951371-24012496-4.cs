    Public Class MyAction
        Inherits Interactivity.TriggerAction(Of UIElement)
    
        Protected Overrides Sub Invoke(parameter As Object)
            MsgBox("Clicked")
        End Sub
    
    End Class
