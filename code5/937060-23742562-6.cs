     //Here is the KeyEventArgs I manually created (Using KeyPress instead of KeyUp). I also set this to public.
        
 
    public void textBox2_KeyPress(object sender, KeyEventArgs e)
            {
        
                if (e.KeyCode == Keys.Back && textBox2.Text.Length == 0)
                    textBox1.Focus();
            }
  
  
        // Here is where the rest of my code was. I set this to private.
            private void textBox2_TextChanged(object sender, EventArgs e)
                {
                if (textBox2.Text == "A")
                    richTextBox3.Text = "January";
    
                if (textBox2.Text == "B")
                    richTextBox3.Text = "February";
    
                if (textBox2.Text == "C")
                    richTextBox3.Text = "March";
    //Code continues below
