     protected void btnView_Click(object sender, EventArgs e)
    {
            if (DropDownList1.SelectedItem.Text == "Membership")// here you can add selectedindex as well
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ToString());
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select columname from tablename where itemanme=Membership", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
          // you can use this datatable dt to get that items and use dt to bind the corresponding control.
               
            }
        }
