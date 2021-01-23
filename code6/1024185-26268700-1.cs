    // create a TableSection to hold the cells
    var section = new TableSection("Customers");
    foreach (var customer in Customers){
        System.Diagnostics.Debug.WriteLine((string)customers["ContactName"]);
        // populate Data on TableView
        var name = (string)customer["ContactName"];
        var position = (string)customer["ContactPosition"]
        var cell = new TextCell { Text = name, Detail = position };
        section.Add(cell);
    }
    // add the section to the TableView root
    tableView.Root.Add(section);
