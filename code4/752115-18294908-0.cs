    public partial class Form2 : Form
    {
        public Form1 ParentForm {get; set;}
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.ParentForm.comboBox1.SelectedItem.ToString());
        }
    }
