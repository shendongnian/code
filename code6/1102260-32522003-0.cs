    protected void GVRequest_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
            int p = Convert.ToInt32(ViewState["Pageindex"]);
            int s = GVRequest.PageSize;
            p = p * s;
            DataTable dtCurrentTable= new DataTable();
            int d = Convert.ToInt32(e.RowIndex);
            int dl = d + p;
            dt = ViewState["CurrentTable"] as DataTable;
        dtCurrentTable.Rows[dl].Delete();
        ViewState["CurrentTable"] = dtCurrentTable;
        DataView view = new DataView(dtCurrentTable);
        DataTable dt1 = view.ToTable(true, "CartonID", "FileID", "FileMasterID", "DeptFileID", "RequestID");
        GVRequest.DataSource = dt1;
        DataBind();
            ViewState["Pageindex"] = 0;
    }
    protected void NextPage(object sender, GridViewPageEventArgs e)
    {
        GVRequest.PageIndex = e.NewPageIndex;
        ViewState["Pageindex"] = e.NewPageIndex;
        GVRequest.DataSource = ViewState["CurrentTable"] as DataTable; //get datasource (list or datatable)
        DataBind();
    }
