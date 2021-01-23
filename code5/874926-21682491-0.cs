    if (SQLDR.Read())
        {
            if (SQLDR["UPassword"].ToString() == Login1.Password.ToString())
            {    
                Session["userName"] = SQLDR["UEmail"].ToString();
                e.Authenticated = true;
            }
            else {
                FailureText.Text = "password is incorrect";
                e.Authenticated = false;
            }    
        }
        else
        {
            FailureText.Text = "User does not exists";
            e.Authenticated = false;
        }
