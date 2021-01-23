    void login()
        {
                var tbl = from s in this.database1DataSet.employee
                          where s.Username == userNameBox.Text
                          select s;
                if(tbl.Count() == 0)
                {
                  MessageBox.Show("User Does not exist");
                  return; // or this.Close(); if it's what you want
                }
                foreach (var s in tbl)
                {
                    if (s.Username == userNameBox.Text && s.Password == passwordBox.Text)
                    {
                        MessageBox.Show("Access granted welcome " + s.fName);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Access denied invalid login details");
                    }
                }
