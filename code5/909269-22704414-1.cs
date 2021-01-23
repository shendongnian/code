    if (keyword_length == 0)
    {
      SearchBlock.Visibility = Visibility.Visible;
      myButton.Text = "Cancel";
    }
    else
    {
      SearchBlock.Visibility = Visibility.Hidden;
      myButton.Text = "Clear";
    }
