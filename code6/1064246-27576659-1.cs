     public partial class Form1 : Form
    {
        //Global variable to store the row numbers
        List<int> rowNumbers = new List<int>();
        public Form1()
        {
            InitializeComponent();
            DataTable myDataTable = new DataTable();
            // Add columns to DataTable.
            myDataTable.Columns.Add("ID",typeof(int));
            myDataTable.Columns.Add("Sample 1", typeof(int));
            myDataTable.Columns.Add("Sample 2", typeof(int));
            
            // Add rows to the DataTable.
            myDataTable.Rows.Add(1, 10, 30);
            myDataTable.Rows.Add(2, 20, 50);
            myDataTable.Rows.Add(3, 20, 80);
            dataGridView1.DataSource = myDataTable.DefaultView;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Loop all rows
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
               //Give the column index which you want for example below i have given 3rd column index
                if (dataGridView1[2, i].Value != null)
                {
                    int cellValue = (int)dataGridView1[2, i].Value;
                    //Check whether the value is less than 48 or not and store the row number in one variable
                    if (cellValue <= 48)
                        rowNumbers.Add(i);
                }
            }
            //Remove the rows which has the cell value < 48
            foreach (var item in rowNumbers)
            {
                dataGridView1.Rows.RemoveAt(item);
            }
        }
    }
