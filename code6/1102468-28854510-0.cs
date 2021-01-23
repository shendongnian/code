    public void AddColumn(string hdr, string colName, int colWidth)
    {
    	DataGridTextBoxColumn tbc = new DataGridTextBoxColumn();
    	tbc.HeaderText = hdr;
    	tbc.MappingName = colName;
    	tbc.Width = colWidth;
    	myTblStyle.GridColumnStyles.Add(tbc);
    }
