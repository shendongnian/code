    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "LinkButton")
            {
                 ShadingAnalysisDataSetTableAdapters.tbl_CadFileUploadTableAdapter cd;
            cd = new ShadingAnalysisDataSetTableAdapters.tbl_CadFileUploadTableAdapter();
            DataTable dt = new DataTable();
            dt = cd.GetGvCad2(ddlSiteID.SelectedValue, int.Parse(Demo));
            gvCadPdf.DataSource = dt;
            gvCadPdf.DataBind();
            }
    }
