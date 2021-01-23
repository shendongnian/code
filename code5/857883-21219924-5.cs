    var items = new List<Address>();
    while (!sr.EndOfStream) {
        string line = sr.ReadLine();
        if (line != null && line.Contains("@")) {
            Address a = Address.FromLine(line);
            items.Add(a);
        }
    }
    myComboBox.DataSource = items;
