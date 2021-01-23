    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            // Insert the columns you require
            dt.Columns.Add("Firstname");
            dt.Columns.Add("Lastname");
            dt.Columns.Add("PhoneNumber");
            
            // This is the only time you need to attach to the DataSource
            dataGridView1.DataSource = dt; 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Add a new row 
            var dr = dt.Rows.Add();
            // And attach the values to the appropriate column
            dr["Firstname"] = tb1.Text;
            dr["Lastname"] = tb2.Text;
            dr["PhoneNumber"] = tb3.Text;
        }
        private void DeleteRow()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dt.Rows[dataGridView1.SelectedRows[0].Index].Delete();
                return;
            }
            if (dataGridView1.SelectedCells.Count > 0)
            {
                dt.Rows[dataGridView1.SelectedCells[0].RowIndex].Delete();
            }
        }
    } 
