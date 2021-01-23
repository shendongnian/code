    DataTable dt = ReadExcelFile(@"c:\\x.xlsx");
    if (dt != null)
    {
        System.Windows.Forms.ComboBox cmb = new System.Windows.Forms.ComboBox();
        for (int i = 0; i < dt.Columns.Count; i++)
    	    cmb.Items.Insert(i, dt.Columns[i].ColumnName);
    }
