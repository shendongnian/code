      private void button1_Click(object sender, EventArgs e)
      {
      SqlDataAdapter SDA = new SqlDataAdapter();
      DataTable dt = new DataTable();
      SqlConnection con = new SqlConnection("Data Source=HOME;Initial   
                               Catalog=Test;Integrated Security=True");
      
      SqlCommand cmd = new SqlCommand("insert into list (pname, pprice)
      select pname, pprice from products where pid='" +textBox1.Text+"'", con);
      con.Open();
      SDA.SelectCommand = cmd;
      SDA.Fill(dt);
      con.Close();
      MessageBox.Show("Product Added");
      
      }
