    protected void DropDownList1_onload(object sender, EventArgs e)
    {
        //SAVE SELECTED
        string selected = "";
        if(DropDownList1.Items.Count > 0 && DropDownList1.SelectedIndex != 0)
        {
             selected = DropDownList1.SelectedValue;
         }
        //UPDATE
        SqlConnection cn = new System.Data.SqlClient.SqlConnection("Data Source=CHANGEME1;Initial Catalog=Reflection;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter("select salary from employee", cn);
        DataSet ds = new DataSet();
        var ddl = (DropDownList)sender;
        da.Fill(ds);
        cn.Close();
        ddl.DataSource = ds;
        ddl.DataTextField = "salary";
        ddl.DataValueField = "salary";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        //RESELECT
        if(!String.IsNullOrEmpty(selected))
        {
             DropDownList1.SelectedValue = selected;
        }
    }
