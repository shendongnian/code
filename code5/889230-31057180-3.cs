    Partial Class Programación_prueba
        Inherits System.Web.UI.Page
    
        Protected Sub UpdateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
            System.Threading.Thread.Sleep(3000)
        End Sub
    
        Protected Sub UpdateTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateTimer.Tick
            Me.UpdateButton_Click(Me.UpdateButton, Nothing)
        End Sub
    End Class
