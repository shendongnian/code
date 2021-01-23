    DataView dv = oraDataSet.Tables[0].DefaultView;
    dv.RowFilter = "Code NOT IN (1,2,3)";
    
    cmbBox1.ValueMember = oraDataSet.Tables[0].Columns["Val1"].ColumnName;
    
    cmbBox1.DisplayMember = oraDataSet.Tables[0].Columns["Disp1"].ColumnName;
    cmbBox1.DataSource = dv;
