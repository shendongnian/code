    class ListBoxItem
    {
        public string Name { get; private set; }
        public string Email { get; private set: }
        public ListBoxItem(string name, string email)
        {
            Name = name;
            Email = email;
        }
        public override string ToString()
        {
            return string.Format("Name: {0} | E-mail: {1}", Name, Email);
        }
    }
    (somewhere you have a List<ListBoxItem> and do something like listBox1.Items.AddRange(itemList))
    private void listBox1_DoubleClick(object sender, EventArgs e)
    {
        ListBoxItem item = (ListBoxItem)listBox1.SelectedItem;
        // use item.Name and item.Email to initialize TextBox values
    }
