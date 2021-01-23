    Private Sub DataGridView_CellMouseDown(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And e.RowIndex <> -1 And e.ColumnIndex <> -1 Then
     
    Dim InvoiceId As Integer =  DataGridView.Rows(e.RowIndex).Cells("InvoiceId").value
    End Sub
