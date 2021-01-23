    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    
    DataSet3TableAdapters.tbl_energy_reportTableAdapter state;
    state = new DataSet3TableAdapters.tbl_energy_reportTableAdapter();
    DataTable dt = new DataTable();
    dt = state.GetDataByClusterInnerJoin(DropDownList1.SelectedValue);
    DropDownList2.DataSource = dt;
    DropDownList2.DataTextField = "cluster";
    DropDownList2.DataValueField = "cluster";
    DropDownList2.DataBind();
    //put it here
    DropDownList2.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Cluster--", "0"));
    }
