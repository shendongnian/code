    Public Class Form1
    
        Private CancelOpening As Boolean = False
    
        Private Sub RadSplitButton1_DropDownOpening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles RadSplitButton1.DropDownOpening
    
            e.Cancel = Me.CancelOpening
    
        End Sub
    
        Private Sub RadSplitButton1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles RadSplitButton1.MouseMove
    
            Me.CancelOpening = Not sender.DropDownButtonElement.ArrowButton.IsMouseOverElement
    
        End Sub
    
        Private Sub RadSplitButton1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles RadSplitButton1.MouseDown
    
            If e.Button = Windows.Forms.MouseButtons.Left AndAlso Me.CancelOpening Then
    
                ' The control is clicked out of the arrow.
                ' Do stuff here
    
            End If
    
        End Sub
    
    End Class
