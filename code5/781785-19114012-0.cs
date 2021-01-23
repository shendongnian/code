    protected void gridView_RowCommand(object sender, object sender, GridViewCommandEventArgs e)
    {
         int rowIndex = Convert.ToInt32(e.CommandArgument);
         gridView.SelectedIndex = rowIndex;
         if (e.CommandName == "DownloadFile")
         {
              DownloadFile(gridView.DataKeys[rowIndex]["FID"].ToString());
         }
    }
