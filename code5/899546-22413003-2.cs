     private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt | e.KeyCode==Keys.F4)
            {
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.H)
            {
                this.Close();
            }
        }
