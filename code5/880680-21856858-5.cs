    string items = "name=value;name2 = valu= = e2";
    
    var nameValues = items
        .Split(';')
        .Select(s => s.Split("=".ToCharArray(), 2))
        .ToDictionary(i => i[0], i => i[1]);
    
    MessageBox.Show("<<<" + nameValues["name2 "] + ">>>");
