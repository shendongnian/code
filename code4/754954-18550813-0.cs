    void dgv_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
    {
    	if (e.ColumnIndex == 2) {
    		if (Convert.ToInt32(this.dgv.Rows(e.RowIndex).Cells(0).Value) > Convert.ToInt32(this.dgv.Rows(e.RowIndex).Cells(1).Value)) {
    			e.Value = "TRUE";
    		} else {
    			e.Value = "FALSE";
    		}
    		e.FormattingApplied = true;
    	}
    }
