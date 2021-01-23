        private void Login()
        {
            int login_count = 0;
            bool goodLogin = false;
            do
            {
                if (DoLogin())
                    goodLogin = true;
                else
                    login_count++;
            } while (login_count < 4 && !goodLogin);
            if (goodLogin)
            {
                //do the login stuff
            }
            else
            {
                Application.Exit();
            }
        }
        private bool DoLogin()
        {
            if (true) //do the login logic here
                return true;
            else
            {
                MessageBox.Show("Invalid username and/or password.");
                pass_txt.Text = null;
                return false;
            }
        }
