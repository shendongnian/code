    string SelectedItem = comboBox2.SelectedItem.ToString();
    var allLines = File.ReadLines(contactpath)
    // Linq filter to exclude selected item
    var newLines = allLines.Where(line => line != SelectedItem);
    File.WriteAllLines(contactpath, newLines);
