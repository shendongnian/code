    private void TextBoxListArray()
    {
        var tb = new TextBox();
        tb.HorizontalAlignment = HorizontalAlignment.Stretch;
        tb.VerticalAlignment = VerticalAlignment.Top;
        tb.TextWrapping = TextWrapping.NoWrap;
        tb.Margin = new Thickness(10);
        tb.Text = i.ToString();
        tb.IsReadOnly = true;
        tb.Height = 40;
        tb.GotFocus += new EventHandler(TextBoxList_GotFocus);
        textBox.Add(tb );
    }
    
    private void TextBoxList_GotFocus(object sender, RoutedEventArgs e)
    {
         var txtBox = sender as TextBox;
         txtBox.Background = new SolidColorBrush(Colors.Yellow); 
    }
