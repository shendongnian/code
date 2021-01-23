    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Disposed += dataGridView_Disposed;
        }
        static void dataGridView_Disposed(object sender, EventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView != null)
            {
                var oldTable = dataGridView.DataSource as IDisposable;
                if (oldTable != null)
                    oldTable.Dispose();
            }
        }
        private void FillDataGridView(object sender, EventArgs e)
        {
            var oldTable = dataGridView1.DataSource as IDisposable;
            DataTable table = GenerateTable();
            dataGridView1.DataSource = table;
            if (oldTable != null)
                oldTable.Dispose();
        }
    }
