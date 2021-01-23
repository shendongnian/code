    public partial class Form1 : Form
    {      
        public Form2 f = new Form2();
        public Form1()
        {
            InitializeComponent();           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            f.Show();
            f.dataGridView2.Rows.Clear();
            foreach (DataGridViewRow d in dataGridView1.SelectedRows)
            {
                f.dataGridView2.Rows.Add(new object[] { d.Cells[0].Value.ToString(), d.Cells[1].Value.ToString() });
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(new object[] { "1", "aaaa" });
            dataGridView1.Rows.Add(new object[] { "2", "bbbb" });
            dataGridView1.Rows.Add(new object[] { "3", "cccc"});
            dataGridView1.Rows.Add(new object[] { "4", "dddd"});
        }
    }
