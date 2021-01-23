    // Create list to hold the text of each list item
    var selectedItemsList = new List<string>();
    // Loop through all of the selected items
    foreach(var listItem in selected)
    {
        // Grab the text value
        selectedItemsList.Add(listItem.Text);
    }
    // Build a string separated by semicolon
    string selectedItemsSeparatedBySemicolon = String.Join(",", 
        selectedItemsList.ToArray());
