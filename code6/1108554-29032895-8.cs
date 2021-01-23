    conn.Open();
        string checkPasswordQuery = "select Password from [AsTable] where Username ='" + ToSHA256(TextBoxUsername.Text) + "'";
        SqlCommand passcom = new SqlCommand(checkPasswordQuery, conn);
        //string password = passcom.ExecuteScalar().ToString().Replace(" ","");
        if (password == ToSHA256(TextBoxPassword.Text))
        {
            Session["New"] = TextBoxUsername.Text;
            Response.Write("Password is correct");
            Response.Redirect("Index.aspx");
        }
        else
        {
            Response.Write("Password is not correct");
        }
    }
    else
    {
        Response.Write("Username is not correct");
    }
    }
