    protected void BindComments(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Item)
    	{
    		AjaxControlToolkit.Accordion myCommentsAccordion = (AjaxControlToolkit.Accordion)e.Item.FindControl("CommentsAccordion");
    		Repeater myCommentRepeater = (Repeater)myCommentsAccordion.FindControl("CommentsRepeater");
    
    		var label = e.Item.FindControl("lblShadeID") as Label;
    		int shadeId = Convert.ToInt32(label.Text);
    		
    		Utility myUtility = new Utility();
    		SqlConnection myConn = myUtility.GetConnection();
    		string myCommandText = "select [CommentID],[ShadeID],[Commenter],[CommentDate],[Comment] from [Comments] where ShadeID = @shadeId order by CommentDate DESC";
    		// set command parameter named @shadeId to the value of shadeId, execute the query and bind data to myCommentRepeater
    	}
    }
