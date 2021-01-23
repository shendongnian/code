    string sql = "SELECT Nickname, Username, Email FROM UserData WHERE (Nickname=?Nickname OR Username=?Username OR  Email=?Email)";
                MySqlCommand check = new MySqlCommand(sql, conn);
                conn.Open();
                check.Parameters.AddWithValue("?Nickname", txtCreateName.Text);
                check.Parameters.AddWithValue("?Username", txtCreateUserName.Text);
                check.Parameters.AddWithValue("?Email", txtCreateEmail.Text);
                MySqlDataReader Reader;
                Reader = check.ExecuteReader();
                List<string> Nicknames = new List<string>();
                List<string> Usernames = new List<string>();
                List<string> Email = new List<string>();
                while (Reader.Read())
                {
                    Nicknames.Add(Reader.GetString(0));
                    Usernames.Add(Reader.GetString(1));
                    Email.Add(Reader.GetString(2));
                }
                conn.Close();
                Reader.Close();
                Boolean alreadyexists = false;
                if (Nicknames.Contains(txtCreateName.Text))
                {
                    alreadyexists = true;
                    lblErrorDisplay.Visible = true;
                }
                if (Usernames.Contains(txtCreateUserName.Text))
                {
                    alreadyexists = true;
                    lblErrorUsername.Visible = true;
                }
                if (Email.Contains(txtCreateEmail.Text))
                {
                    alreadyexists = true;
                    lblErrorEmail.Visible = true;
                }
                if (alreadyexists)
                {
                    return;
                }
