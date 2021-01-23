    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason != CloseReason.WindowsShutDown)
        {
            if (MessageBox.Show(...) == DialogResult.No)
            {
                e.Cancel = true;
                this.Activate();
            }
        }   
    }
