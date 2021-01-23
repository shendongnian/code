    foreach (TableCell c in gv.HeaderRow.Cells) {
    	if (c.HasControls) {
    		c.Text = (c.Controls(0) as LinkButton).Text;
    		c.Controls.Clear();
    	}
    }
