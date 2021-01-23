    private void Zero(object sender, RoutedEventArgs e)
    {
        if (Convert.ToDouble(textBoxContents) > 0 ||
            textBoxContents[textBoxContents.Length - 1] == '.')
        {
            if(selectedFunction != 0)
                textBoxContents = textBoxContents + "0";
        }
        else if (textBoxContents == null)
        {
            textBoxContents = textBoxContents + "0";
        }
        ResultBox.Content = textBoxContents;
    }
