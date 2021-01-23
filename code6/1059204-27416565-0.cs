            bool authenticated = false;
            WebClient client = new WebClient();
            string userinfoLines = client.DownloadString("http://pastebin.com/raw.php?i=LAUx2zxn");
            foreach (string userinfo in userinfoLines.Split(new[] {Environment.NewLine},StringSplitOptions.RemoveEmptyEntries))
            {
            if (userinfo == username.Text + ":" + password.Text)
            {
                authenticated = true;
                MessageBox.Show("Successfully logged in as " + username.Text + ".", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                label1.Text = "Welcome, " + username.Text;
                label1.Visible = true;
                this.Hide();
                MainMenu ss = new MainMenu();
                ss.Show();
                break;
            }
            }
            if (!authenticated)
            {
                // Login failed, I added my own stuff here.
                MessageBox.Show("Invalid account info entered.\n If you want to buy an account msg\n YouRGenetics \nOn Skype\n Or Click On Buy Account", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
