     Dim SIRCON as string =  "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/Srihari/OrionSystem.accdb"
    Using con As New OleDbConnection(SIRCON)
            con.Open()
            Dim strSQL As String = "select * from invoice_top where invoice_number=" + textEdit5.Text
            dim dt as new datatable
            dt.Load(New OleDbCommand(strSQL, conexiune).ExecuteReader())
            conexiune.Close()
            GridControl1.datasource = dt
            GridControl1.ForceInitialise
           
        End Using
