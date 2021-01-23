    Private Sub TabControl1_Click(sender As System.Object, e As System.EventArgs) Handles TabControl1.Click
        Dim m As System.Windows.Forms.MouseEventArgs = DirectCast(e, System.Windows.Forms.MouseEventArgs)
        Dim tabWidth As Integer =
            Convert.ToInt32(Me.CreateGraphics().MeasureString(TabControl1.SelectedTab.Text, TabControl1.Font).Width)
        Debug.Print(m.X & " " & m.Y & " " & tabWidth)
    End Sub
