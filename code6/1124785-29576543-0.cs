    private KeyCode m_keyCode;
    private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        this.m_keyCode = e.KeyCode;
    }
    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
         if (this.m_keyCode == Keys.Enter)
         {
             MessageBox.Show("Enter Key Pressed ");
         }
    }
