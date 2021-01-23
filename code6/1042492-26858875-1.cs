       textBox1.TextChanged += anyTextBox_TextChanged; 
  
       textBox6.TextChanged += anyTextBox_TextChanged; 
    private void anyTextBox_TextChanged( object sender, TextChangedEventArgs e )
    {
      // ... ask the button to check its own state. 
      button1_CheckState(); 
    }
    private void button1_CheckState() 
    {
     // Assume all is well to start with 
      bool state = true ; 
     foreach ( TextBox textBox in textBoxes_ )
      if ( "".Equals( textBox.Text ) ) 
      {
         // If it's not, disable the button. 
         state = false ; 
         break ;
      }
     button1.Enabled = state ; 
    }
