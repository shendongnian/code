       using (SqlBulkCopy bulkCopy = new SqlBulkCopy(
                           connectionString, SqlBulkCopyOptions.KeepIdentity |
                           SqlBulkCopyOptions.UseInternalTransaction))
       {
           ....
       }
