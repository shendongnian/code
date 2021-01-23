    public void EditGridData(object sender, GridViewCommandEventArgs e)
        {
            int i = Convert.ToInt32(e.CommandArgument);
            Session["Country_ID"] = i;
    
            if (e.CommandName == "Edit1")
            {
                SortedList sl = new SortedList();
                sl.Add("@mode", "GetRows1");
                sl.Add("@Country_ID", i);
                SqlDataReader dr = emp.GetDataReaderSP("CountryMaster1", sl);
                while (dr.Read())
                {
                    txtCountry.Text = dr["Country_Name"].ToString();
                    txtDesc.Text = dr["Description"].ToString();
                    ViewState["Country_Name"] = dr["Country_Name"].ToString();
                    BtnSubmit.Visible = true;
                    BtnSubmit.Text = "Update";
                }
            }
    
            if (e.CommandName == "View1")
            {
                SortedList sl = new SortedList();
                sl.Add("@mode", "GetRows1");
                sl.Add("@Country_ID", i);
                SqlDataReader dr = emp.GetDataReaderSP("CountryMaster1", sl);
                while (dr.Read())
                {
                    txtCountry.Text = dr["Country_Name"].ToString();
                    txtDesc.Text = dr["Description"].ToString();
                    ViewState["Country_Name"] = dr["Country_Name"].ToString();
    
                    BtnReset.Visible = true;
                    BtnSubmit.Visible = false;
                }
            }
    
    
            if (e.CommandName == "Delete1")
            {
                SortedList sl = new SortedList();
                sl.Add("@mode", "DeleteData");
                sl.Add("@Country_ID", i);
    
                emp.ExecuteNonQuerySP("CountryMaster1", sl);
                Label1.Visible = true;
                Label1.Text = "Record Deleted Successfully…";
                BindGrid();
            }
    
        }
