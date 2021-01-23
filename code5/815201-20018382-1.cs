    private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Up)
                {
                    button1.Focus();
                }
    
               if (e.KeyCode == Keys.Down)
                {
                   button2.Focus();
                }
                 if (e.KeyCode == Keys.Left)
                    {
                      button3.Focus();
                    }
    
                 if (e.KeyCode == Keys.Right)
                    {
                       button4.Focus();
                    }
            }
