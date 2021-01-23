    namespace TestSortWithSum
    {
        public partial class Form1: Form
        {
            public Form1()
            {
                this.InitializeComponent();
        
                DataTableSumSortableDGV dataGridView1 = new DataTableSumSortableDGV();
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.DataSource = GetSumTable();
                dataGridView1.SumColumnIndices.Add(3);
                dataGridView1.SumColumnIndices.Add(4);
                dataGridView1.LabelColumnIndex = 2;
                dataGridView1.LabelColumnText = "Total";
                this.Controls.Add(dataGridView1);
            }
        
            private DataTable GetSumTable()
            {
                DataTable table = new DataTable();
        
                table.Columns.Add("Foo", typeof(string));
                table.Columns.Add("Bar", typeof(string));
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Amount", typeof(decimal));
                table.Columns.Add("Quantity", typeof(int));
        
                table.Rows.Add("Foo  1", "Bar  7", "Abcd", 1.11, 1);
                table.Rows.Add("Foo  2", "Bar  8", "Hijk", 2.22, 2);
                table.Rows.Add("Foo  3", "Bar  9", "Qrs", 3.33, 3);
                table.Rows.Add("Foo  4", "Bar 10", "W", 4.44, 4);
                table.Rows.Add("Foo  5", "Bar  1", "Y", 5.55, 5);
                table.Rows.Add("Foo  6", "Bar  2", "Z", 6.66, 1);
                table.Rows.Add("Foo  7", "Bar  3", "X", 7.77, 2);
                table.Rows.Add("Foo  8", "Bar  4", "Tuv", 8.88, 3);
                table.Rows.Add("Foo  9", "Bar  5", "Lmnop", 9.99, 4);
                table.Rows.Add("Foo 10", "Bar  6", "Efg", 1.11, 5);
        
                return table;
            }
        }
    }
