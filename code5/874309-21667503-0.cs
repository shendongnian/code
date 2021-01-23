            foreach (FileInfo file in Files)
            {
                lvi = new ListViewItem();
                string s = file.Name.ToString();
                char[] arr = s.ToCharArray();
                lvi.Text = s;
                localPlayers.Items.Add(lvi);
            }
            
