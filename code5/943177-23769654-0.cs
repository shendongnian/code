    private void button2_Click_2(object sender, RibbonControlEventArgs e)
        {
            
            SqlDataSourceEnumerator dse = SqlDataSourceEnumerator.Instance;
            DataTable dt = dse.GetDataSources();
            if (dt.Rows.Count == 0)
            {
               // return null;
            }
            string[] SQLServers = new string[dt.Rows.Count];
            int f = -1;
            foreach (DataRow r in dt.Rows)
            {
                string SQLServer = r["ServerName"].ToString();
                string Instance = r["InstanceName"].ToString();
                if (Instance != null && !string.IsNullOrEmpty(Instance))
                {
                    int i = 0; SQLServer += "\\" + Instance;
                }
                SQLServers[System.Math.Max(System.Threading.Interlocked.Increment(ref f), f - 1)] = SQLServer;
            }
            Array.Sort(SQLServers);
            for(int i = 0; i < SQLServers.Length; i++)
            {
               
                
                RibbonDropDownItem item = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
                item.Label = SQLServers.GetValue(i).ToString();
                //item.Label = "yourtext";
                comboBox1.Items.Add(item);
            }
        }
