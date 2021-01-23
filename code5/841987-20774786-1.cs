       this.KeyPreview=true;
       private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control  &&  e.KeyCode == Keys.C)
            {
                MessageBox.Show("Ctrl+C Pressed");
                     /*write your code*/
            }
            if (e.Control  &&  e.KeyCode == Keys.K)
            {
                MessageBox.Show("Ctrl+K Pressed");
                     /*write your code*/
            }
        }
