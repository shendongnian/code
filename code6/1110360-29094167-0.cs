    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private DataTable table;
        private void button1_Click(object sender, EventArgs e)
        {
            var work = new Action(GetData);
            using (var f2 = new Form2(work))
            {
                f2.ShowDialog();
                this.dataGridView1.DataSource = this.table;
            }
        }
        private void GetData()
        {
            this.table = new DataTable();
            using (var adapter = new SqlDataAdapter("SELECT * FROM MyTable", "connectionstring here"))
            {
                adapter.Fill(table);
            }
        }
    }
    public partial class Form2 : Form
    {
        private Action work;
        public Form2(Action work)
        {
            InitializeComponent();
            this.work = work;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.work();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
