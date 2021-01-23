    Private posx, posy As Integer
    Private Sub Form1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        canMove = 1
        posx = MousePosition.X
        posy = MousePosition.Y
    End Sub
    Private Sub Form1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If canMove = 1 And (posx <> MousePosition.X Or posy <> MousePosition.Y) Then
            MoveForm()
        End If
        posx = MousePosition.X
        posy = MousePosition.Y
    End Sub
