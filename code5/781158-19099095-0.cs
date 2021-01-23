    private void listView1_MouseDoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    path = Convert.ToString(listView1.Items[i]);
                    // This replaces the part "List View Item: {"
                    path = path.Replace("ListViewItem: {", "");
                    // This replaces the part "}"
                    path = path.Replace("}", "");
                    comboBox1.Text = path;
                    listView1.Items.Clear();
                    LoadFilesAndDir(path);
                }
            }
        }
