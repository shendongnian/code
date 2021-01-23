                string queryString = "SELECT * FROM dbo.Licenses";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sEnv);
    
                DataSet Licenses = new DataSet();
                adapter.Fill(Licenses, "Licenses");
                int iLicensesRows = Licenses.Tables[0].Rows.Count;
                foreach (DataRow row in Licenses.Tables[0].Rows)
                {
                ListViewItem LVI = lstLicenses.Items.Add(row["Company"].ToString());
                LVI.SubItems.Add(row["ExpiryDate"].ToString());
                LVI.SubItems.Add(row["MaxUsers"].ToString());
                LVI.SubItems.Add(row["Key"].ToString());
                }
    
               //Comment or remove the below statements to get design time widths.
    
               /*lstLicenses.Columns[0].Width = 100;
                lstLicenses.Columns[1].Width = 130;
                lstLicenses.Columns[2].Width = 85;
                lstLicenses.Columns[3].Width = 225; */
