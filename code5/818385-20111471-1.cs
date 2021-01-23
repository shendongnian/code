    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "1", "2", "3" });
        }
        private string _comboValue { get; set; }
        public string ShowAndGetComboValue()
        {
            this.ShowDialog();
            return _comboValue;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _comboValue = comboBox1.SelectedItem.ToString();
        }
    }
