        private void AddItem(DirectoryEntry de)
        {
            comboBox2.Items.Add(de.Properties["GivenName"].Value.ToString() + " " + de.Properties["sn"].Value.ToString() + " " + "[" + de.Properties["sAMAccountName"].Value.ToString() + "]");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "All")
            {
                this.backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                //Do Something!!!
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Bind to the users container.
            DirectoryEntry entry = new DirectoryEntry("LDAP://CN=xyz,DC=com");
            // Create a DirectorySearcher object.
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            try
            {
                // Create a SearchResultCollection object to hold a collection of SearchResults
                // returned by the FindAll method.
                SearchResultCollection result = mySearcher.FindAll();
                int count = result.Count;
                for(int i = 0; i < count; i++)
                {
                    SearchResult resEnt = result[i];
                    try
                    {
                        DirectoryEntry de = resEnt.GetDirectoryEntry();
                        BeginInvoke(new Action<DirectoryEntry>(AddItem), de);
                    }
                    catch (Exception)
                    {
                        // MessageBox.Show(e.ToString());
                    }
                    this.backgroundWorker1.ReportProgress(i / count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar1.Value = 100;
        }
