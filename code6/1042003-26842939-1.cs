    private void richTextBox2_SelectionChanged(object sender, EventArgs e)
    {
      // mixed state:   
      if (richTextBox2.SelectionFont == null)
      {
         checkBox1.CheckState = CheckState.Indeterminate;
         checkBox2.CheckState = CheckState.Indeterminate;
         return;
     }
     checkBox1.Checked = 
       (richTextBox2.SelectionFont.Style & FontStyle.Bold) != FontStyle.Regular;
     checkBox2.Checked = 
       (richTextBox2.SelectionFont.Style & FontStyle.Italic) != FontStyle.Regular;
    }
