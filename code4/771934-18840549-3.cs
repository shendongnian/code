    private void TextBoxListArray()
    {
        var tb =  new TextBox() { Text = textBox.Count(), ....... };
        tb.GotFocus += new EventHandler(TextBoxList_GotFocus);
        textBox.Add(tb);
        stackNotes.Children.Add(tb);
    }
    
    private void TextBoxList_GotFocus(object sender, RoutedEventArgs e)
    {
         var txtBox = sender as TextBox;
         txtBox.Background = new SolidColorBrush(Colors.Yellow); 
    }
