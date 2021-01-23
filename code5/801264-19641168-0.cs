    Private Sub dgvTaskLog_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTaskLog.CellContentClick
        Dim frm As New frmCalendar
        frm.ShowDialog()
        If IsDate(frm.outSelectedDate) Then
            dgvTaskLog(e.ColumnIndex, e.RowIndex).Value = frm.outSelectedDate
        End If
    End Sub
