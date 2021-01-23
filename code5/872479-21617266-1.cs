        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == imageList1.Images.Count)
            {
                timer1.Stop();
                i = 0;
            }
            button1.Image = imageList1.Images[i];
            i++;        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        } 
