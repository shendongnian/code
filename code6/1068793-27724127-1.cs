        private void Init()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { Text = "displayText1", Value = "ValueText1" });
            items.Add(new Item() { Text = "displayText2", Value = "ValueText2" });
            items.Add(new Item() { Text = "displayText3", Value = "ValueText3" });
            comboBox1.DataSource = items;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
        }
        public class Item
        {
            public Item() { }
            public string Value { set; get; }
            public string Text { set; get; }
        }
