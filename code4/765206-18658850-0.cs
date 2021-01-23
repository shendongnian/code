        DirectoryEntry adEntry = null;
        private void SetADInfoAndCredentials()
        {
            adEntry = new DirectoryEntry("LDAP://" + ad_textBox.Text);
            adEntry.Username = user_textBox.Text;
            adEntry.Password = pw_textBox.Text;
        }
        private void SearchForMailInAD()
        {
            DirectorySearcher adSearcher = new DirectorySearcher(adEntry);
            adSearcher.Filter = ("mail=" + mail_textBox.Text);
            SearchResultCollection coll = adSearcher.FindAll();
            foreach (SearchResult item in coll)
            {
                foundUsers_listBox.Items.Add(item.GetDirectoryEntry());
            }
        }
