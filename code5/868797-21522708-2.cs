    If e.ColumnIndex = 3 Then
                        Dim c As DataGridViewComboBoxColumn
      		
    
    
    Dim cmd2 As New SqlCommand("select DName from Designation_tbl where deleted=0", con.connect)
    
    cmd2.CommandType = CommandType.TExt
    
    
    dim objdataadapter as SqlDataAdapter(cmd2)     
    
    Dim results As New DataSet()
    
    
    da.Fill(results, "tblProductCatalog")
    c.DataSource = results["tblProductCatalog"]
    c.ValueMember = "ID"
    c.DisplayMember = "Item"
     con.disconnect()
    end if
     
                 
