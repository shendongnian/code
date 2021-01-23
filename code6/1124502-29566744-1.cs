    bool LoggedIn= false;
    string x = null;
    for (int i = 0; i < Val.Length/2; i += 2)
    {
        if (TextBox1.Text == Val[i])
        {
            if (TextBox2.Text == Val[i + 1])
            {
                Session.Add("UserName", Val[i]);
                x = "HomePage";
                LoggedIn = true;
                break;
             }
             else
                LoggedIn = false;
                    
        }
    }
    if(LoggedIn)
      Response.Redirect(x + ".aspx");
    else
      Label1.Text = "Incorrect Password.";
