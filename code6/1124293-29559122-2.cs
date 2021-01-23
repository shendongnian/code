     con = new SqlConnection(MyConnectionString);
                con.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand= new SqlCommand("select * from ' " + DropDownList1.SelectedValue.ToString() + " ' where SUPP_NAME like ' " + TextBox1.Text + "%' ");
  
                myReader = myCommand.ExecuteReader();
  
                GridView1.DataSource = dr;
                GridView1.DataBind();
                con.Close();
