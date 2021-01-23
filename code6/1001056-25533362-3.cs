    using(DataTableReader reader = new DataTableReader(new DataTable[] { customer }))
    {
         do
         {
             if(reader.HasRows)
             {
                  // Do Something
             }
         } while (reader.NextResult());
    }
