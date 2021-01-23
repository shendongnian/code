    SqlConnection cnn ;
                string connectionString = null;
                string sql = null;
    
                connectionString = "data source=SERVERNAME;initial catalog=DATABASENAME;user id=USERNAME;password=PASSWORD;";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                sql = "SELECT Product_id,Product_name,Product_price FROM Product";
                SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
                DataSet1 ds = new DataSet1();
                dscmd.Fill(ds, "Product");
                MessageBox.Show (ds.Tables[1].Rows.Count.ToString());
                cnn.Close();
    
                CrystalReport1 objRpt = new CrystalReport1();
                objRpt.SetDataSource(ds.Tables[1]);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();
