    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    	for (int i = 1; i < e.Row.Cells.Count; i++)
    	{
    		string cellValue = e.Row.Cells[i].Text.Trim();
    		Literal literal = e.Row.Cells[i].FindControl("literalUrl") as Literal;
    		Image imageUrl = e.Row.Cells[i].FindControl("imageUrl") as Image;
    		if (literal != null && imageUrl != null)
    		{
    			if (literal.Text.StartsWith("http:"))
    			{
    				imageUrl.ImageUrl = literal.Text.Trim();
    				imageUrl.Viisible = true;
    				literal.Visible = false;
    			}
    		}
    	}
    }
