        private void Form1_Load(object sender, EventArgs e)
        {
            
            panel1.BackgroundImageLayout = ImageLayout.Center;
            //panel1.BackgroundImageLayout = ImageLayout.None;
        }
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            panel1.Height = panel1.Size.Height - 1;
            panel1.Width = panel1.Size.Width - 1;
        }
        private void btnZommin_Click(object sender, EventArgs e)
        {
            panel1.Height = panel1.Size.Height + 1;
            panel1.Width = panel1.Size.Width + 1;
        } 
