    private class ComboItem
    {
        public string ItemText  { get; set; }
        public float  ItemFloat { get; set; }
    
        public ComboItem(string itemText, float itemFloat)
        {
            this.ItemText  = itemText;
            this.ItemFloat = itemFloat;
        }
    
        public override string ToString()
        {
            return this.ItemText;
        }
    }
    
    private void AddItemsToComboBox
    {
        comboBox1.Items.Add(new ComboItem("One Point Two", 1.2f));
        comboBox1.Items.Add(new ComboItem("Three Point Four", 3.4f));
    }
    
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedFloat = ((ComboItem)comboBox1.SelectedItem).ItemFloat;
        Debug.Print("Selected: " + selectedFloat);
    }
