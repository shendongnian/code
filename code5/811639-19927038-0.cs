    private void Form2_Load(object sender, EventArgs e)
                {
                    ds = new DataSet();
                    dc = new DataService();
                    DataTable td = dc.GetData("Select * from Customers", "CustomerID");
                    foreach (DataRow dr in td.Rows)
                    {
                        this.comboBox1.Items.Add(dr["CustomerID"]);
                    }
                }
