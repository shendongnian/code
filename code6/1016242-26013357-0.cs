       bool check = false;
       foreach (XmlNode item in xd.SelectNodes("mylogin/login"))
        {
            user += (item.SelectSingleNode("user").InnerText) + ",";
        }
        user = user.TrimEnd(',');
        usernames = user.Split(',');
        //==============
        foreach (XmlNode item in xd.SelectNodes("mylogin/login"))
        {
            pass += (item.SelectSingleNode("pass").InnerText) + ",";
        }
        pass = pass.TrimEnd(',');
        passwords = pass.Split(',');
        //============
        if (textBox1.Text != "" || textBox2.Text != "")
        {
            for (int i = 0; i < passwords.Length; i++)
            {
                if (textBox1.Text == usernames[i] && textBox2.Text == passwords[i])
                {
                    this.Hide();
                    new Form2().Show();
                }
                else
                {
                   check = true;
                }
            }
            if(check)
            {
              MessageBox.Show("Wrong");
            }
        }
        else
        {
            MessageBox.Show("please fill user & password");
        }
    }
