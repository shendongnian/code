      static void ProcessQuery(CloudTable table, string pk)
      {
         string pkFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, pk);
         TableQuery<TableEntity> query = new TableQuery<TableEntity>().Where(pkFilter);
         var list = table.ExecuteQuery(query).ToList();
         foreach (TableEntity entity in list)
         {
            // Process Entities
         }
      }
