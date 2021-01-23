    using (DataTableReader reader = new DataTableReader(
               new DataTable[] { customerDataTable, productDataTable }))
    {
        // Print the contents of each of the result sets. 
        do
        {
            PrintColumns(reader);
        } while (reader.NextResult());
    }
