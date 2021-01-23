    bool flag = true;
    private void pictureBox1_Click(object sender, EventArgs e)
        {
                pictureBox1.Image = flag ? WindowsFormsApplication2.Properties.Resources.Greek_flag 
                                         : WindowsFormsApplication2.Properties.Resources.English_flag;
            flag = !flag;
        }
