    bool newStart; 
    int startIndex;
    //SelectionChanged event handler for richTextBox1
    private void richTextBox1_SelectionChanged(object sender, EventArgs e)
    {
         //record the new SelectionStart
         if (newStart) startIndex = richTextBox1.SelectionStart;                        
    }
    //KeyDown event handler for richTextBox1
    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
         newStart = char.IsControl((char)e.KeyCode) ||
                             ((int)e.KeyCode < 41 && (int)e.KeyCode > 36);
    }
    //KeyUp event handler for richTextBox1
    private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
    {
         newStart = true;//This makes sure if we change the Selection by mouse
         //the new SelectionStart will be recorded.
    }
    //KeyPress event handler for richTextBox1
    private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
       if (e.KeyChar == ' '){
          MessageBox.Show(richTextBox1.Text.Substring(startIndex, richTextBox1.SelectionStart - startIndex));          
          newStart = true;
       }                   
    }
