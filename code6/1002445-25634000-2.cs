    Public Class RadSplitButton_TestForm
    ''' <summary>
    ''' Flag that determines whether the RadSplitButton menu-opening should be canceled.
    ''' </summary>
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
    Handles RadSplitButton1.Click
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso Me.CancelOpening Then
            MsgBox("clicked out the arrow!")
        ElseIf Not Me.CancelOpening Then
            MsgBox("clicked over the arrow!")
        End If
    End Sub
    End Class
