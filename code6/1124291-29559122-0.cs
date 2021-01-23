     con = new SqlConnection(MyConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from ' " + DropDownList1.SelectedValue + " ' where SUPP_NAME like ' " + TextBox1.Text + "' ");
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                con.Close();
