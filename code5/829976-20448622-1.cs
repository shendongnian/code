    foreach(User _user in users)
    {
       if(_user.connectionid == TextBox1.Text)
       {
          TextBox2.Text = _user.nick;
          break;
       }
    }
