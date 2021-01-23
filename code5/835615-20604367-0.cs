    SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();
            foreach (System.Data.DataRow row in table.Rows)
            {
                cboServerName.Items.Add(row["ServerName"]);
            }
