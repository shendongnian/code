    private void buttan_Click_2(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            if (a == "Well")
            {
                pictureBox1.Visible = false;
                axWindowsMediaPlayer1.URL = @"c:\Users\Galym\Desktop\123.mp4";
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {  
                MessageBox.Show("Try again");
            }
