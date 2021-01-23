            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\sample.txt");
            string line = null;
            int linecounter = 0;
            //structure to hold data to be written to the database
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("company");
            table.Columns.Add("sector");
            table.Columns.Add("operation");
            table.Columns.Add("license");
            table.Columns.Add("expiry");
            table.Columns.Add("contact");
            table.Columns.Add("email");
            table.Columns.Add("address");
            System.Data.DataRow row = null;
            while ((line = file.ReadLine()) != null)
            {
                //create a new table row if the line is {0,8,16,...}
                if (linecounter % 8 == 0)
                    row = table.NewRow();
                string[] values = line.Split(':');
                //put the data in the appropriate column based on "linecounter % 8"
                row[linecounter % 8] = values[1];
                //add the row to the table if its been fully populated
                if (linecounter % 8 == 7)
                    table.Rows.Add(row);
                linecounter++;
            }
            file.Close();
            string connectionString = "<CONNECTION STRING GOES HERE>";
            using (System.Data.SqlClient.SqlBulkCopy copy = new System.Data.SqlClient.SqlBulkCopy(connectionString))
            {
                copy.DestinationTableName = "MyTable";
                copy.WriteToServer(table);
            }
