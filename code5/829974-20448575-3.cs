    protected void Button2_Click(object sender, EventArgs e)
    {
      try
      {
         //I want to find connectionid from TextBox1, write the matching User nick into TextBox2
         string tempid = TextBox1.Text.Trim();
         List <User> data = (from user in users 
                                  where user.connectionid == tempid  
                             select user).ToList();
        foreach(User aUser in data)
        {
          TextBox2.Text = aUser .nick;
        }
      }
      catch(Exception ex)
      {
        //Handle exception
      }
