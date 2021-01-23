        private void Button1_Click(object sender, EventArgs e)
        {
            //declare new SaveFileDialog + set it's initial properties
	            SaveFileDialog sfd = new SaveFileDialog {
		            Title = "Choose file to save to",
		            FileName = "example.csv",
		            Filter = "CSV (*.csv)|*.csv",
		            FilterIndex = 0,
		            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
	            };
	            //show the dialog + display the results in a msgbox unless cancelled
                if (sfd.ShowDialog() == DialogResult.OK) {
                    
                    string[] headers = ListView1.Columns
                               .OfType<ColumnHeader>()
                               .Select(header => header.Text.Trim())
                               .ToArray();
                    string[][] items = ListView1.Items
                                .OfType<ListViewItem>()
                                .Select(lvi => lvi.SubItems
                                    .OfType<ListViewItem.ListViewSubItem>()
                                    .Select(si => si.Text).ToArray()).ToArray();
                    string table = string.Join(",", headers) + Environment.NewLine;
                    foreach (string[] a in items)
                    {
                        //a = a_loopVariable;
                        table += string.Join(",", a) + Environment.NewLine;
                    }
                    table = table.TrimEnd('\r', '\n');
                    System.IO.File.WriteAllText(sfd.FileName, table);
                }
        }
