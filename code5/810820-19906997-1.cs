        private void YourFormName_SizeChanged(object sender, EventArgs e)
        {
            this.Width = 300; // the default or initial width
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                
               if (textBox1.Text.Length == 0)
                {
                    this.Width = 300;
                    goto END;
                }
                if (textBox1.Text.Length < this.Width)
                    this.Width = textBox1.Text.Length;
                else
                    this.Width = this.Width + textBox1.Text.Length;
            END:this.Text = textBox1.Text;
            }
        }
