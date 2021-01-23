    protected void QuestionList_ItemCreated(Object sender, DataListItemEventArgs e)
        {
            Control uploadButton =  e.Item.FindControl("btnUpload");
            Control DownloadLinkButton = e.Item.FindControl("LinkButton1");                                
            if (uploadButton != null)
            {
                ScriptManager mgr = ScriptManager.GetCurrent(this.Page);                
                mgr.RegisterPostBackControl(uploadButton);
                mgr.RegisterPostBackControl(DownloadLinkButton);                
            }
        }
