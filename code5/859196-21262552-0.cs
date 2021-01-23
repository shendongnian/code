    var x = new List<int>() { 1, 2, 3 };
    
    var printer = new Printer();
    
    // this assignment does not copy the list - it assigns the property to the same list
    printer.UserList = x;
    
    // verify that the reference was copied, not the data
    x.Add(4);
    printer.UserList.Add(5);
    
    MessageBox.Show(x.Count.ToString()); // shows 5
    MessageBox.Show(printer.UserList.Count.ToString()); // also shows 5
