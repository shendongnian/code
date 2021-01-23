    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    End Sub
    Protected Sub BindGrid(searchText As String)
        Dim connection As New OleDbConnection("myconnection")
        Dim cmd As New OleDbCommand
        Dim sql As String = "SELECT * FROM OPENQUERY([xxxx.NET\CSI], 'SELECT * FROM SReader.table1 WHERE CurrentCostCenter IN(''27177'') ')"
        cmd.Parameters.AddWithValue("@CurrentCostCenter", searchText)
        Dim dt As New DataTable()
        Dim ad As New OleDbDataAdapter(cmd)
        ad.Fill(dt)
        If dt.Rows.Count > 0 Then
            'check if the query returns any data
            GridView1.DataSource = dt
            GridView1.DataBind()
            'No records found
        Else
        End If
        
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        BindGrid(TextBox1.Text.Trim())
    End Sub
