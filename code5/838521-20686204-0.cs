    private void Form1_Load(object sender, EventArgs e)
            {
                numericUpDown1.TextChanged += new EventHandler(numericUpDown1_TextChanged);
            }
    
            void numericUpDown1_TextChanged(object sender, EventArgs e)
            {
                CloudEnteringAlert.tolerancenum = (int)numericUpDown1.Value;
                pictureBox1.Image = CloudEnteringAlert.CloudsOnly(bitmapwithclouds, bitmapwithoutclouds);
            }
