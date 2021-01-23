    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public TextBox TextBoxWithSameText { get; set; }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxWithSameText != null)
                TextBoxWithSameText.Text = textBox2.Text;
        }
    }
