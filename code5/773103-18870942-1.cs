    private void button2_Click(object sender, EventArgs e)
    { 
        PictureBox pb = tabControl1.SelectedTab.Controls.OfType<PictureBox>()
                           .FirstOrDefault(p=>p.Name == "picturebox1name");
        if(pb != null)
         pb.Image = WindowsFormsApplication7.Properties.Resources.logo2; 
    }
