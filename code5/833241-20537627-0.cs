    Private Sub ListView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles ListView1.ColumnWidthChanged
    Static busy As Boolean = False
    If busy Then Exit Sub
    busy = True
    ListView1.Columns(e.ColumnIndex).Width = 90
    busy = False
    End Sub
