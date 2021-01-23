    private void Zero(object sender, RoutedEventArgs e)
    {
        var dblVal = Convert.ToDouble(textBoxContents.Text);
        textBoxContents.Text = dblVal.ToString();
        ResultBox.Content = textBoxContents.Text;
    }
