    public partial class Form2 : Form
    {
        public Color getColor { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getColor = Color.Red;
            DialogResult = DialogResult.OK;
        }
    }
