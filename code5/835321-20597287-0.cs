    protected void OnRowCommand(object server, GridViewCommandEventArgs e) 
    { 
        // Don't use Windows Message Box
        int rowindex = Convert.ToInt32(e.CommandArgument);
        var lblFileId = gvAssignReviewer.Rows[rowindex].FindControl("lblFileId") as Label;
        var txtReviewerId = gvAssignReviewer.Rows[rowindex].FindControl("txtReviewerId") as TextBox; 
        if(lblFileId != null && txtReviewerId != null)
        {
            int fileId;
            int urevId;
    
            if(int.TryParse(lblFileId.Text, out fileId) && int.TryParse(txtReviewerId.Text, out urevId) )
            {
                    ur.UpdateReviewer(fileId, urevId); 
            }
        } 
        Bind(); 
    }
