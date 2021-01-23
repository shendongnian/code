    public static DataTable GetComboBoxedDataTable(DataTable oldDataTable, string valueColumn, string textColumn, string topRowValue, string topRowText, ComboBox cmb)
    {
        DataTable newDataTable = oldDataTable.Copy();
        DataRow dr = newDataTable.NewRow();
        dr[0] = topRowValue;
        dr[1] = topRowText;
        newDataTable.Rows.InsertAt(dr, 0);
    	
        cmb.ValueMember = valueColumn;
        cmb.DisplayMember = textColumn;
    	cmb.DataSource = newDataTable;
        return newDataTable;
    } 
