    private void OnClick_button_switchText( object sender, RoutedEventArgs e )
    {
         // Switch text
         string text1  = textBox1.Text;
         textBox1.Text = textBox2.Text;
         textBox2.Text = text1;
         
         // Scroll to end - without focus
         textBox1.ScrollToHorizontalOffset( double.PositiveInfinity );
         textBox2.ScrollToHorizontalOffset( double.PositiveInfinity );
         
         // Scroll to end - and focus the first TextBox
         textBox1.Focus();
         EditingCommands.MoveToLineEnd.Execute( null, textBox1 );
         textBox2.ScrollToHorizontalOffset( double.PositiveInfinity );
         
         // Scroll to end - and focus the second TextBox
         textBox1.ScrollToHorizontalOffset( double.PositiveInfinity );
         textBox2.Focus();
         EditingCommands.MoveToLineEnd.Execute( null, textBox2 );
    }
  
  
