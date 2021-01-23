    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow) {
    		//Reference the date1 label in Gridviews template field
    		System.Web.UI.WebControls.Label date1 = (System.Web.UI.WebControls.Label)e.Row.FindControl("date1");
    		GridViewRow myRow = e.Row;
    		//set back color to green if incident category is hazard
    		if (date1 < DateTime.Now)
                 {
    			   e.Row.BackColor = Drawing.Color.SpringGreen;
    		    }	
    	}
    }
