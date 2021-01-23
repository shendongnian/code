    protected void cblGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedValues = string.Empty;
        foreach (ListItem item in cblGroup.Items)
        {
            if (item.Selected)
                selectedValues += "'" + item.Value + "',";
        }
        if (selectedValues != string.Empty)
            selectedValues = selectedValues.Remove(selectedValues.Length - 1);
        SqlConnection con = new SqlConnection(strcon);
        con.Open();      
        SqlCommand cmd = new SqlCommand("select [Code] from Details where [Group] in (" + selectedValues + ")", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        cblCode.DataSource = ds;
        cblCode.DataTextField = "Code";
        cblCode.DataValueField = "Code";
        cblCode.DataBind();                   
    }
