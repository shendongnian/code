    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                List<MyListItem> item = new List<MyListItem>();
                item.Add(new MyListItem{Text = "A", Value ="1"});
                item.Add(new MyListItem { Text = "B", Value = "2" });
                item.Add(new MyListItem { Text = "C", Value = "3" });
                comboBox1.DataSource = item;
                comboBox1.DisplayMember = "Text";
                comboBox1.ValueMember = "Value";
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // This one not throw the null refference exception
                var ss = comboBox1.SelectedValue.ToString();
            }
        }
        struct MyListItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
