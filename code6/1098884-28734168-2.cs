    private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;
                UpdateProgress.Enabled = true;
            }
        }
        private void UpdateProgress_Tick(object sender, EventArgs e)
        {
            //Do some work
            if (progressBar1.Value < progressBar1.Maximum) 
            {
                progressBar1.Value++;
            }
            
            if (Control.ModifierKeys == Keys.Alt)
            {
                UpdateProgress.Enabled = false;
            }
        }
 
