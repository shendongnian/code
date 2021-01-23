       this.KeyPreview=true;
       private bool isFirstKeyPressed= false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {               
                isFirstKeyPressed = true;                
            }
            
            if (isFirstKeyPressed)
            {
                if (e.Control && e.KeyCode == Keys.K)
                {
                    MessageBox.Show("Ctrl+C and Ctrl+K pressed Sequentially");
                    /*write your code here*/
                    isFirstKeyPressed= false;
                }
            }
        }
