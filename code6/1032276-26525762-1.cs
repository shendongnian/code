    protected void Button1_Click(object sender, EventArgs e)
        {
            SiteDetailsDataSetTableAdapters.tbl_SiteDetailsTableAdapter cd;
            cd = new SSiteDetailsDataSetTableAdapters.tbl_SiteDetailsTableAdapter();
            cd.GetUpdateCadAssign(ddlState.SelectedValue);
        }
