    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //label.Text = _cmb.SelectedItem.ToString();  // it says Object reference not set to an instance of an object.
            //label.Text += _cmb.SelectedText.ToString();   // it returns ""
            //label.Text += _cmb.SelectedValue.ToString();  // it says Object reference not set to an instance of an object.
            ComboBoxItem item = (ComboBoxItem) this._cmb.SelectedItem;
            if (item != null)
            {
                label.Text = item.Value.ToString();
                label.Text += item.Text;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this._cmb.ValueMember = "Value";
            this._cmb.DisplayMember = "Text";
            this._cmb.Items.AddRange(new[] {
                new ComboBoxItem() { Selectable = false, Text="Unselectable", Value=0},
                new ComboBoxItem() { Selectable = true, Text="Selectable1", Value=1},
                new ComboBoxItem() { Selectable = true, Text="Selectable2", Value=2},
            });
            this._cmb.SelectedIndexChanged += (cbSender, cbe) =>
            {
                var cb = cbSender as ComboBox;
                if (cb.SelectedItem != null && cb.SelectedItem is ComboBoxItem && ((ComboBoxItem)cb.SelectedItem).Selectable == false)
                {
                    // deselect item
                    cb.SelectedIndex = -1;
                }
            };
        }
    }
    public class ComboBoxItem
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public bool Selectable { get; set; }
    }
