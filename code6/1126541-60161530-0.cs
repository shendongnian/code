    enter code here
  
    private void Form4_Load(object sender, EventArgs e)
        {
            //I am assuming f1 is the name of your original Form1
            String f1DataGridViewName = f1.dataGridView1.Name.ToString();
            int f1RowCount = f1.RowCount;
            string billinfo = string.Empty;
            Console.Writeline("Form1 f1 Datagridview name is: {0}
                               ,Form1 f1 DataGridview row count is : {1}"
                               ,f1DataGridViewName, f1RowCount );
            foreach (DataGridViewRow row in f1.dataGridView1.Rows)
            {
                billinfo = string.Format("{0}{1} {2} {3}{4}", billinfo
                         , row.Cells["Name"].Value
                         , row.Cells["Amount"].Value
                         , row.Cells["Price"].Value
                         , Environment.NewLine);
            }
            textBox1.Text = billinfo;
        }
