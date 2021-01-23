        private void getNumbers()
        {
            SqlCeConnection con = new SqlCeConnection(@"Data Source=|DataDirectory|\LWADataBase.sdf;");
            try
            {
                con.Open();
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            treeView1.Nodes.Clear();
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM orderTBL ORDER BY[Order Number] ASC", con);
            try
            {
                //Temp List
                List<string> ordersLoaded = new List<string>();
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string oderNum = dr["Order Number"].ToString();
                    //Check if you loaded that order already
                    if (!ordersLoaded.Contains(oderNum))
                    {
                        //Add order to loaded list
                        ordersLoaded.Add(oderNum);
                        treeView1.Nodes.Add(new TreeNode(oderNum));
                    }
                }
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            con.Close();
        }
