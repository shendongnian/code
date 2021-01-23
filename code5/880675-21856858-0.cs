    string items = "name=value;name2 = valu= = e2";
    
    // Split the list on items.
    var itemlist = items.Split(';');
    // Split each item after the first '='.
    var nameValueArrayList = itemlist.Select(s => s.Split("=".ToCharArray(), 2));
    // Convert the list of arrays to a dictionary
    var nameValues = nameValueArrayList.ToDictionary(i => i[0], i => i[1]);
    
    MessageBox.Show("<<<" + nameValues["name2 "] + ">>>");
