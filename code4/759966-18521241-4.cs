    private void gvPhoneQueue_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
    {
    	if (gvPhoneQueue.Columns(e.ColumnIndex).HeaderText == "CallsWaiting") {
    		int convertVal = 0;
    		if (int.TryParse(e.Value.ToString, convertVal)) {
    			if (convertVal > _redTolerance) {
    				gvPhoneQueue.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red;
    			} else if (convertVal > _yellowTolerance) {
    				gvPhoneQueue.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow;
    			} else if (convertVal > _greenTolerance) {
    				gvPhoneQueue.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Green;
    			}
    		} else {
    			//can't convert e.value
    		}
    	}
    }
