    private void backSpaceButton_Click(object sender, RoutedEventArgs e)
    {
        if (!String.IsNullOrEmpty(displaytxt.Text))
        {
            displaytxt.Text = displaytxt.Text.Substring(0, displaytxt.Text.Length - 1);
        }
    }
