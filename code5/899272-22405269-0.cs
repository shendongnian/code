    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        var element = (sender as TextBox);
        if (!theTextBoxWasValidated())
        {
            // doing this would cause a StackOverflowException
            // element.Focus();
     
            var restoreFocus = (System.Threading.ThreadStart)delegate { element.Focus(); };
            Dispatcher.BeginInvoke(restoreFocus);
        }
    }
