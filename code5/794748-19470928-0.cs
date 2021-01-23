    string SelectedItem = comboBox2.SelectedItem.ToString();
    string newLines = File.ReadLines(contactpath)
        // Linq filter to exclude selected item
        .Where(line => line != SelectedItem);
    File.WriteAllLines(contactpath, newLines);
