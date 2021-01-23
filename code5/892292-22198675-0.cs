    if(string.IsNullOrEmpty(myObject.Title))
    {
    GridLayout.Visibility = Visibility.Collapsed;
    Title.Text=string.Empty;
    }
    else
    {
    Title.Text = myObject.Title;
    GridLayout.Visibility = Visibility.Visible;
    }
