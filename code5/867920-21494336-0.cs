    protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
         //re-assign your DataSource
         dsActivity myDataSet = new dsActivity();
         myDataSet = clsDataLayer.GetActivity(Server.MapPath("DB.mdb"));
         grdActivity.DataSource = myDataSet.Tables["tblActivity"];
         //Set the new page index
         grdActivity.PageIndex = e.NewPageIndex;
         //apply your changes
         grdActivity.DataBind();
    }
