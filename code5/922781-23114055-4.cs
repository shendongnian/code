    // build a list of the column mappings
    List<Mapping> mappings = new List<Mapping>();
    mappings.Add(new Mapping{ csv_cols = new int[] { 0 },    db_column_name = "Email" });
    mappings.Add(new Mapping{ csv_cols = new int[] { 1 },    db_column_name = "FirstName" });
    mappings.Add(new Mapping{ csv_cols = new int[] { 2 },    db_column_name = "MiddleName" });
    mappings.Add(new Mapping{ csv_cols = new int[] { 3 },    db_column_name = "LastName" });
    mappings.Add(new Mapping{ csv_cols = new int[] { 1, 3 }, db_column_name = "DisplayName", col_format = "{0} {1}" });
    List<string> columns = new List<string>();
    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ToString()))
    {
        conn.Open();
		// get a list of all the database columns
        using (var cmd = new System.Data.SqlClient.SqlCommand("SELECT column_name FROM MyDatabase.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'Contact'", conn))
        {
            cmd.CommandType = CommandType.Text;
            System.Data.SqlClient.SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                var col = sdr.GetValue(0).ToString();
                columns.Add(col);
            }
            sdr.Close();
        }
		// get the db column for each mapping
        foreach (Mapping p in mappings)
        {
            p.db_col_num = columns.FindIndex(x => x.ToLower() == p.db_field.ToLower());
        }
				
		// create our custom data reader
        CustomDataReader cdr = new CustomDataReader(mappings, columns.ToArray(), csv, true);
        // bulkcopy data to Contacts table
        using (var bulkCopy = new System.Data.SqlClient.SqlBulkCopy(conn))
        {
            bulkCopy.DestinationTableName = "Contact";
            bulkCopy.WriteToServer(cdr);
        }
    }
