    // Populate the ComboBox
    var values = new ComboBoxValue[]
    {
        new ComboBoxValue() { ID = 1, Name = "Test" },
        new ComboBoxValue() { ID = 2, Name = "Test 2" },
    };
    comboBox1.Items.AddRange(values);
    ...
    // Set selected item based on an ID
    int id = 1;
    comboBox1.SelectedItem = values.Single(x => x.ID == id);
