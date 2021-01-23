    public DataTable GetData(string SQLQuery)
    {
       string strCon = ConfigurationManager.ConnectionStrings["ST"].ConnectionString.ToString();
       string strSQL = "SQL QUERY";
       SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, strCon);
       SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
       DataTable table = new DataTable();
       table.Locale = System.Globalization.CultureInfo.InvariantCulture;
       dataAdapter.Fill(table);
    }
    
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
       //Maybe only one of the clear code works.
       dataGridView1.Rows.Clear();
       dataGridView1.DataSource = null; 
       
       BindingSource bindingSource1 = new BindingSource();
       bindingSource1.DataSource = GetData("SQL QUERY");
       dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
       dataGridView1.ReadOnly = true; //<-----------Try taking this off aswell
       dataGridView1.DataSource = bindingSource1;
    }
