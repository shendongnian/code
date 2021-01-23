        private void button2_Click(object sender, EventArgs e)
            { 
                PictureBox pb = null;
    
                foreach (Control c in tabControl1.SelectedTab.Controls)
                    if (c is PictureBox)
                    {
                        pb = c as PictureBox;
                        break;
                    }
    
                pb.Image = WindowsFormsApplication7.Properties.Resources.logo2; 
            }
