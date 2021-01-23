        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               if(boolean_var){
                   this.RefToForm1.textBox1.Text=textBox2.Text;
                   this.Close();
               }
            }
        }
