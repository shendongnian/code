    protected void RadGrid4_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                GridEditableItem eitem = e.Item as GridEditableItem;
                FileUpload photoTextBox = eitem.FindControl("photoTextBox") as FileUpload;
                TextBox personalidTextBox = eitem.FindControl("personalidTextBox") as TextBox;
                Label photoLabel = eitem.FindControl("photoLabel") as Label;
    
                string filename = String.Format("{0}.jpg",personalidTextBox.Text);           
                string uploadPath = string.Format("~/ImageStorage/{0}",fileName)
                photoTextBox.SaveAs(Server.MapPath(uploadPath));
                ViewState["UploadPath"]=uploadPath;
                // use the above viewstate path to save in db in gridview rowupdating event and bind the grid again
              }
     }
