    protected void Register_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DB_Users.mdf;Integrated Security=True");
        SqlCommand insert = new SqlCommand("insert into tbl_users(name, username, password,email) values(@name, @username, @password,@email)", conn);
        insert.Parameters.AddWithValue("@name", txtname.Text);
        insert.Parameters.AddWithValue("@username", txtusername.Text);
        insert.Parameters.AddWithValue("@password", txtpassword.Text);
        insert.Parameters.AddWithValue("@email", txtemail.Text);
        try
        {
            conn.Open();
            insert.ExecuteNonQuery();
            lbl_msg.Text = "Register done !";
          //lbl_msg.Text = "ثبت نام با موفقیت انجام شد";
        }
        catch (Exception ex)
        {
            lbl_msg.Text = "Error: "+ex.Message;
          //lbl_msg.Text = "خطا در ارتباط با پایگاه داده";
            conn.Close();
        }
    }
