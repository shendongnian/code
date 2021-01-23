    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var cbi1 = new ComboBoxItem("Item 1") { Id = 1 };
            var cbi2 = new ComboBoxItem("Item 2") { Id = 2 };
            var cbi3 = new ComboBoxItem("Item 3") { Id = 3 };
            comboBox1.Items.Add(cbi1);
            comboBox1.Items.Add(cbi2);
            comboBox1.Items.Add(cbi3);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = ((ComboBoxItem)comboBox1.SelectedItem).Id;
            MessageBox.Show(id.ToString());
        }
    }
    public class ComboBoxItem
    {
        private readonly string text;
        public int Id { get; set; }
        public ComboBoxItem(string text)
        {
            this.text = text;
        }
        public override string ToString()
        {
            return text;
        }
    }
