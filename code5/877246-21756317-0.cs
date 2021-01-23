    SqlCommand xp = new SqlCommand("Insert into userdatabase(Username, Email,
        Password)Values(@Username, @Email, @Password)", User);
                    xp.Parameters.AddWithValue("@Username", InputUsername.Text);
                    xp.Parameters.AddWithValue("@Email", InputEmail.Text);
                    xp.Parameters.AddWithValue("@Password", InputPassword.Text);
