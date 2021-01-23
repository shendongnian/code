    private void graphicBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        graphicList.Items.Clear();
        string selectedfolder = SkinSuite.Properties.Settings.Default.exepath + "\\GRAPHIC\\" + graphicBox.SelectedItem;
        graphicfiles = Directory.GetFiles(SkinSuite.Properties.Settings.Default.exepath + "\\GRAPHIC\\" + graphicBox.SelectedText);
        // MessageBox.Show("FOR SOME REASON THIS DOESNT WORK IF I DONT SHOW YOU A MESSAGEBOX!");
        foreach (string file in graphicfiles)
        {
           graphicList.Items.Add(Path.GetFileName(file));
        }
     }
