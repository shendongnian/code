            // Creating DataSource here as datatable having two columns
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name");
            // Adding the rows in datatable
            for (int iCount = 1; iCount < 6; iCount++)
            {
                var row = dt.NewRow();
                row["ID"] = iCount;
                row["Name"] = "Name " + iCount;
            }
            DataGridView dgv = new DataGridView();
            // Set AutoGenerateColumns true to generate columns as per datasource.
            dgv.AutoGenerateColumns = true;
            // Finally bind the datasource to datagridview.
            dgv.DataSource = dt;
