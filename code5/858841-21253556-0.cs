        public void read()
        {
            try
            {
                using(OracleConnection conn = new OracleConnection("....."))
                using(OracleCommand cmd = new OracleCommand("select * from t1", conn))
                {
                    conn.Open();
                    using(OracleDataReader reader = cmd.ExecuteReader())
                    {
                         DataTable dataTable = new DataTable();
                         dataTable.Load(reader);
                         dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     }
