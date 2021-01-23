    private void CopyDataGridViewToClipboard(ref DataGridView dgv)
    {
    	string s = "";
    	DataGridViewColumn oCurrentCol = default(DataGridViewColumn);
    	//Get header
    	oCurrentCol = dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
    	do {
    		s += oCurrentCol.HeaderText + Strings.Chr(Keys.Tab);
    		oCurrentCol = dgv.Columns.GetNextColumn(oCurrentCol, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
    	} while (!(oCurrentCol == null));
    	s = s.Substring(0, s.Length - 1);
    	s += Environment.NewLine;
    	//Get rows
    	foreach (DataGridViewRow row in dgv.Rows) {
    		oCurrentCol = dgv.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
    		do {
    			if (row.Cells(oCurrentCol.Index).Value != null) {
    				s += row.Cells(oCurrentCol.Index).Value.ToString;
    			}
    			s += Strings.Chr(Keys.Tab);
    			oCurrentCol = dgv.Columns.GetNextColumn(oCurrentCol, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
    		} while (!(oCurrentCol == null));
    		s = s.Substring(0, s.Length - 1);
    		s += Environment.NewLine;
    	}
    	//Put to clipboard
    	DataObject o = new DataObject();
    	o.SetText(s);
    	Clipboard.SetDataObject(o, true);
    }
