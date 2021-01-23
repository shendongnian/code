    protected void GridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.DataRow) {
    	}
    
    	if (e.Row.RowType == DataControlRowType.DataRow) {
    		Label lblColor1 = default(Label);
    
    		lblColor1 = e.Row.FindControl("lblColor") as Label;
    
    		lblColor1.Text = dtData.Rows(e.Row.RowIndex).ItemArray(0).tostring();
    		// 
    		// ItemArray Defined the Column Position. here give your Another Colour Column Value
    	}
    
    }
