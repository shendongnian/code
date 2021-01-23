    private void Confirm_Click(object sender, RoutedEventArgs e)
    {
        string playerName;
        string userInput = "";  // An empty string is a match for your pattern
        Regex r = new Regex("^[a-zA-Z]*$");
        if (r.IsMatch(userInput))
        {
           ...
