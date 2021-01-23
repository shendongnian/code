    private void button2_Click(object sender, EventArgs e)
    { 
        TabControl actualTabControl = tabControl1.SelectedTab.Controls.OfType<TabControl>()
                                                 .FirstOrDefault();
        if(actualTabControl != null){
         PictureBox pb = actualTabControl.SelectedTab.Controls["picturebox1name"] as PictureBox;
         if(pb != null)
            pb.Image = WindowsFormsApplication7.Properties.Resources.logo2; 
        }
    }
