    private void Confirm_Click(object sender, RoutedEventArgs e)
    {
        string playerName;
        string userInput = userInput.Text;
        Regex r = new Regex("^[a-zA-Z]*$");
        if (r.IsMatch(userInput))
        {
           ...
