    // get records with the id 4
    var myList = GetMyList(4);
    // get the property called Column1 for each one of those records and add them to this list (for demonstration)
    var listOfColumn1 = new List<string>(); // lets assume that column holds a string
    foreach(User usr in myList)
    {
        listOfColumn1.Add(thing);
    }
    // or in a more linq-ish way
    listOfColumn1 = myList.Select(record => record.Column1).ToList();
