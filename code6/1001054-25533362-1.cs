    using(DataTableReader reader = new DataTableReader(new DataTable[] { customer }))
    {
         do
         {
             if(reader.HasRows)
             {
                  PrintData(reader);
             }
         } while (reader.NextResult());
    }
