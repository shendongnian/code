    protected void ddlSiteID_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(@"connectionString"))
        {
            con.Open();
            string selectID = ddlSiteID.SelectedValue;
            using (SqlCommand cmd = new SqlCommand("SELECT Site_Name,Site_Address FROM tbl_Survey1 where   Site_ID=@Site_ID", con))
            {
                cmd.Parameters.AddWithValue("@Site_ID", selectID);
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        txtSiteName.Text = rdr.GetString(0);
                        txtSiteAddress.Text=rdr.GetString(1);
                    }
                }
            }
        }
    }
