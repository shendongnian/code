    private void submit_Click(object sender, EventArgs e)
    {
       if(!UserNameCheck())
       {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Data Source=LFC;Initial Catalog=contactmgmt;Integrated Security=True";
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "INSERT INTO cntc_employee (emp_f_name,emp_l_name,emp_alias,emp_contact_no,emp_address,emp_company,emp_bdate) VALUES(@fname,@lname,@alias,@contact,@address,@company,@bdate)";
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@fname", textBox1.Text);
        cmd.Parameters.AddWithValue("@lname", textBox2.Text);
        cmd.Parameters.AddWithValue("@alias", textBox3.Text);
        cmd.Parameters.AddWithValue("@contact", textBox4.Text);
        cmd.Parameters.AddWithValue("@address", textBox5.Text);
        cmd.Parameters.AddWithValue("@company", textBox6.Text);
        cmd.Parameters.AddWithValue("@bdate", textBox7.Text.ToString());
        
        cmd.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("Data Inserted Succesfully");
     }
    }
