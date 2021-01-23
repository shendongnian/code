    private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumLock && numLock==false)
                numLock = true;
            else
                numLock=false; 
               
             e.Handled = true;                   
             getNumLockState_Click(sender, e);   
        }
        private void getNumLockState_Click(object sender, EventArgs e)
        {
            
            if (numLock == true)
            {
                lblNumlock.Text = "Numlock On";               
            }
            if (numLock == false)
            {
                lblNumlock.Text = "Numlock Off";
            }
        }
