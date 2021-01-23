        public static int GetDbSizeInMB([NotNull] string connectionString) {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand()) {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = @"
                        SELECT SUM(CAST(FILEPROPERTY([name],'SpaceUsed') AS int)/128.0) AS [UsedSpaceInMB]
                        FROM sys.database_files
                        WHERE type_desc like 'ROWS' or type_desc like 'FULLTEXT'
                        ";
                    sqlCommand.Connection = sqlConnection;
                    return Convert.ToInt32(sqlCommand.ExecuteScalar());
                }
            }
)
