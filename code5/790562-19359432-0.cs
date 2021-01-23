    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        string rval = DropDownList1.SelectedValue.ToString();
       
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        string qry = "select Roomnum from room where rtype=@rval and rstatus like 'AV'";
        SqlCommand cmd = new SqlCommand(qry,con);
        cmd.Parameters.AddWithValue("@rval",rval);
        SqlDataReader rd1 = cmd.ExecuteReader();
        if (rd1.HasRows)
        {
            while (rd1.Read())
            {
                    DropDownList2.Items.Add(rd1[0].ToString());
            }
        }
        con.Close();
    }
    
