    protected void dlComments_ItemDataBound(object sender, DataListItemEventArgs e)
    {
    	FileUpload lFileUpload = (FileUpload)e.Item.FindControl("fileUploadReply");
    	PostBackTrigger lTrigger = new PostBackTrigger();
    	lTrigger.ControlID = lFileUpload.ID;
    	UpdatePanel.Triggers.Add(lTrigger);
    }
