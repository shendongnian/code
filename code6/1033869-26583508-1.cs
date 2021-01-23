                using (SqlTransaction transaction =
                           destinationConnection.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(
                               destinationConnection, SqlBulkCopyOptions.KeepIdentity,
                               transaction))
                    {
                         ....
                    }
                }
