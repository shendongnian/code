    ListViewItem newFolder;
    private void buttonNewFolder_Click(object sender, EventArgs e)
            {
                newFolder = listView1.Items.Add("New folder", 1);
                newFolder.BeginEdit();
            }
    
    
    private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
            {
                Directory.CreateDirectory("C:\"+e.Label); //for example
                //You now have access to newFolder here
            }
