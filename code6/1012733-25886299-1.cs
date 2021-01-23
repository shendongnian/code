    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
    private void Test()
    {
        ComboboxItem item = new ComboboxItem();
        item.Text = "Supervisor";
        item.Value = 111;
    
        comboBox1.Items.Add(item);
    }
