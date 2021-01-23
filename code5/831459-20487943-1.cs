    protected void btnSearchEmpCode_Click(object sender, EventArgs e)
    {
        string selectedValues = string.Empty;
        foreach (ListItem item in cblEmpCode.Items)
        {
            if (item.Selected)
                selectedValues +=  item.Value + ",";
        }
       
        if (selectedValues != string.Empty)
            selectedValues = selectedValues.Remove(selectedValues.Length - 1);
        SqlConnection con = new SqlConnection(strcon);
        SqlCommand cmd = new SqlCommand("SELECT * FROM Details WHERE Emp_Code IN (" + selectedValues + ")", con);
        SqlDataAdapter Adpt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        Adpt.Fill(dt);
        AIGrids.DataSource = dt;
        AIGrids.DataBind();
    }
