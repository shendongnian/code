    if (SQLDR.HasRow())
    {
        if(SQLDR.Read())
        {
            if (SQLDR["UEmail"].ToString() == Login1.UserName.ToString())
            {
                if (SQLDR["UPassword"].ToString() == Login1.Password.ToString())
                {
                    Session["userName"] = SQLDR["UEmail"].ToString();
                    e.Authenticated = true;
                }
                else
                {
                    FailureText.Text = "password is incorrect";
                    e.Authenticated = false;
                }
            }
        }
    }
    else
    {
        FailureText.Text = "User does not exists";
        e.Authenticated = false;
    }
