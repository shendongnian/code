    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
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
