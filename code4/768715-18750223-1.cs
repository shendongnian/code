    Private blIsUserClick As Boolean
    Private Sub CheckBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.MouseDown
        blIsUserClick = True
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If blIsUserClick Then
            'Is a user click event
        Else
            'Not a user click event
        End If
    End Sub
    Private Sub CheckBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.MouseUp
        blIsUserClick  = False
    End Sub
