        using (CsvDataReader csvData = new CsvDataReader(path, ',', Encoding.UTF8))
        {
            // will read in first record as a header row and
            // name columns based on the values in the header row
            csvData.Settings.HasHeaders = true;
            csvData.Columns.Add("nvarchar");
            csvData.Columns.Add("float"); // etc.
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = "DestinationTable";
                bulkCopy.BulkCopyTimeout = 3600;
                // Optionally, you can declare columnmappings using the bulkCopy.ColumnMappings property
                bulkCopy.WriteToServer(csvData);
            }
        }
