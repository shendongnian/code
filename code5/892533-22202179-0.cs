    protected void gvOrderRowCreated(object sender, GridViewRowEventArgs e)
    {
    	switch (e.Row.RowType) {
    		case DataControlRowType.DataRow:
    			Button btn = (Button)e.Row.FindControl("btnED");
    			btn.Command += btnED_Click;
    			break;
    	}
    }
