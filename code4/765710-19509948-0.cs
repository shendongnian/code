        DateTime startDate;
        DateTime endDate;
        if (DateTime.TryParse(txtstart.Text, out startDate) && DateTime.TryParse(txtend.Text, out endDate))
        {
            //string n1 = DropDownList2.SelectedItem.Text;
            if (DropDownList1.SelectedItem.Text == "Membership")
            {
                SqlConnection con = new
          SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString());
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select p.Name,m.FID,m.MembNo,m.MembType,m.Validity,m.Remarks from Membership_det m INNER JOIN Personal_det p  ON m.FID= p.FID where m.updateDate  between @Start and @End ", con);
                adapter.SelectCommand.Parameters.Add("@Start", SqlDbType.Date).Value = startDate;
                adapter.SelectCommand.Parameters.Add("@End", SqlDbType.Date).Value = endDate;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            log.Debug("Info: Admin viewed the membership details");
        }
