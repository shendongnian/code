    // Your code
    private void DataGrid_Loaded(object sender, RoutedEventArgs e)
    {    
        // getElement is a weird name for this object :)
        XDocument getElement = XDocument.Load("details.xml");
        // Create your List of ColmNames outside the foreach to use later
        var items = new List<ColumnNames>();
    
        foreach (var npc in getElement.Descendants("user"))
        {
            string id = npc.Attribute("id").Value;
            string Name = npc.Attribute("Name").Value;
            string Surname = npc.Attribute("Surname").Value;
            string Computer = npc.Attribute("Computer").Value;
    
            // You are adding an item to the existing List<ColumnNames> now, not a new one each time
            items.Add(new ColumnNames(id, Name, Surname, Computer));
        }
        // Finally, get a reference to the grid and set the ItemsSource property to use
        // your full list containing all the items
        var grid = sender as DataGrid;
        grid.ItemsSource = items;
    }
