    private void gvPhoneQueue_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        int convertVal = 0;
        if (int.TryParse(e.Value.ToString, convertVal))
        {
    	    if (convertVal > _redTolerance) 
            {
    		    gvPhoneQueue.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red;
    		    return;
    	    }
    	    if (convertVal > _yellowTolerance)
            {
    		    gvPhoneQueue.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow;
    		    return;
    	    }
    	    if (convertVal > _greenTolerance) 
            {
    		    gvPhoneQueue.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Green;
    		    return; // not really required here...
    	    }
        }
        else 
        {
    	    //can't convert e.value
        }
    }
