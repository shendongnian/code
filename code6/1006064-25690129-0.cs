    textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
    textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    AutoCompleteStringCollection items = new AutoCompleteStringCollection();
    items.Add("Save");
    items.Add("Don't Save");
    textBox1.AutoCompleteCustomSource = items;
