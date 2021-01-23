        delegate void populateProdOrders(DataTable dt);
        public void safePopulate(DataTable dt)
        {
            if (this.dataGridView2.InvokeRequired)
            {
                populateProdOrders d = new populateProdOrders(safePopulate);
                this.Invoke(d, new object[] { dt });
            }
            else this.dataGridView2.DataSource = dt;
        }
        public Form1()
        {
            // stuff
            System.Timers.Timer refreshProdOrders = new System.Timers.Timer(5000);
            refreshProdOrders.Elapsed += refreshProdOrders_Elapsed;
            refreshProdOrders.AutoReset = true;
            refreshProdOrders.Enabled = true;
        }
        void refreshProdOrders_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //dostuff();
            var globes = SharedResourceVariables.globals;
            DataTable dt = new DataTable();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(globes.SQLConn);
            using (conn)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("development_usp_viewProdductionOrders", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (cmd)
                {
                    conn.Open();
                    System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    conn.Close();
                }
            }
            safePopulate(dt);
        }
