    SqlCommand insertUser = new SqlCommand(insCmd, con);
    insertUser.Parameters.AddWithValue("@Username", TextBox1Username.Text);
    insertUser.Parameters.AddWithValue("@Password", TextBox2Password.Text);
    insertUser.Parameters.AddWithValue("@EmailAddress", TextBox4Email.Text);
    insertUser.Parameters.AddWithValue("@FullName", TextBox???????.Text);
    insertUser.Parameters.AddWithValue("@City", TextBox6City.Text);
