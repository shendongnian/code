    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int indexDdl = DropDownList1.SelectedIndex;
        indexDdl++;
        Session["doctorId"] = indexDdl;
        if (IsPostBack)                                                          <==new code added
        {
            DataPager pgr = ListView1.FindControl("DataPager1") as DataPager;    <==new code added
            if (pgr != null && ListView1.Items.Count != pgr.TotalRowCount)       <==new code added
            {
                pgr.SetPageProperties(0, pgr.MaximumRows, false);                <==new code added
            }
        }
        ListAppointement(indexDdl);
    }
