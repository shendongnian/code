    public static void BulkInsert<T>(this Repository repository, IEnumerable<T> objects) where T : class
            {
                var bulkCopy = new ObjectBulkCopy<T>();
                var connection = (SqlConnection) repository.Database.Connection;
                bulkCopy.Insert (objects, connection);
            }
