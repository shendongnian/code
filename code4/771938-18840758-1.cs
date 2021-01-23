    private void TextBoxListArray()
        {
            textBox.Add(new TextBox());
            int i = textBox.Count();
            i = i - 1;
            tally = i - 1;
            textBox[i].HorizontalAlignment = HorizontalAlignment.Stretch;
            textBox[i].VerticalAlignment = VerticalAlignment.Top;
            textBox[i].TextWrapping = TextWrapping.NoWrap;
            textBox[i].Margin = new Thickness(10);
            textBox[i].Text = i.ToString();
            textBox[i].IsReadOnly = true;
            textBox[i].Height = 40;
            stackNotes.Children.Add(textBox[i]);
            textBox[i].GotFocus += new RoutedEventHandler(TextBoxList_GotFocus);
            textBox[i].LostFocus += new RoutedEventHandler(TextBoxList_LostFocus);
        }
 
        private void TextBoxList_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBoxSender = sender as TextBox;
            textBoxSender.Background = new SolidColorBrush(Colors.Beige);
        }
        private void TextBoxList_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBoxSender = sender as TextBox;
            textBoxSender.Background = new SolidColorBrush(Colors.White);
        }
