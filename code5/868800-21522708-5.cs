    If e.ColumnIndex = 3 Then
                   
     Dim c As DataGridViewComboBoxColumn
    
    
        Dim cmd2 As New SqlCommand("select Did,DName from Designation_tbl where deleted=0", con.connect)
        cmd2.CommandType = CommandType.Text
        Dim objdataadapter As New SqlDataAdapter(cmd2)
        Dim results As New DataSet
    
        objdataadapter.Fill(results, "DesignationMaster_tbl")
        c = DGVEmployee.Columns(3)
        c.DataSource = results.Tables("DesignationMaster_tbl")
        c.ValueMember = "Did"
        c.DisplayMember = "DName"
        con.disconnect()
        end if
         
                 
