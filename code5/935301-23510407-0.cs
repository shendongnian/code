    private void BrokerWiseSalesReport_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = null;
            dataGridView1.Rows.Clear();
            ds = GetBrokerDetailspageload();
            MySqlDataAdapter msd= new MySqlDataAdapter();
            msd.Fill(ds);
            //int ii = 0;            
            //if (ds.Tables[0].Rows.Count != 0)
           // {
                dataGridView1.DataSource = ds;
            // }
         }
