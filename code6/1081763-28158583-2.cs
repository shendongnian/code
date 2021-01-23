        private int Number_of_Images;
        
        private void label1_Click(object sender, EventArgs e)
        {
            label1.Enabled = false;
            Number_of_Images++; 
            label1.Text = "Clicks: " + Number_of_Images.ToString();
            System.Threading.Thread.Sleep(3000);
            label1.Enabled = true;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            label2.Enabled = false;
            Number_of_Images++;
            label2.Text = "Clicks: " + Number_of_Images.ToString();
            System.Threading.Thread.Sleep(3000);
            Application.DoEvents();
            label2.Enabled = true;
        }
