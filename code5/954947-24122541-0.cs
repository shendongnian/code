    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("asdf");
            dataGridView1.Rows.Add("qwer");
            dataGridView1.Rows.Add("yxcv");
            dataGridView1.Rows.Add("asdf");
            dataGridView1[0, 3] = new DataGridViewTextBoxCell();
        }
    }
