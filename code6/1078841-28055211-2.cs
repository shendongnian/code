        private bool SanityCheck()
        {
            if (listBoxSitesWithFetchedData.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a site first!");
                return false;
            }
            bool pass = ((!(String.IsNullOrEmpty(textBoxUsername.Text.Trim())))
                && (!(String.IsNullOrEmpty(textBoxPwd.Text.Trim()))));
            if (!pass)
            {
                MessageBox.Show("You have not yet provided some key data; be sure to enter a username and a password");
            }
            return pass;
        }
