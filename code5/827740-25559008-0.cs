    Private SyncObj As New Object
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
            Threading.Monitor.Enter(SyncObj)
            ToolStripProgressBar1.Value = RowIndex / Dt.Rows.Count * 100
            ToolStripStatusLabel1.Text = (Dt.Rows.Count - RowIndex).ToString & " left"
            Threading.Monitor.Exit(SyncObj)
    End Sub
