    public partial class EquationSolver : Form
    {
        int z = 0; //class level
        int y;
        public EquationSolver()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            z = Convert.ToInt32(textBox1.Text);
            z = int.Parse(textBox1.Text);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            y = Convert.ToInt32(textBox1.Text);
            y = int.Parse(textBox1.Text);
        }
    }
