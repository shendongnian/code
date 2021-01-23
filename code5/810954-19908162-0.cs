        /// <summary>
        /// Execute a non-query with a retry to handle collisions with non-identity keys
        /// </summary>
        /// <remarks>The command is retried while unique constraint or duplicate key errors occur
        /// <note type="caution">To be meaningful the command must try different values on each try
        /// e.g. INSERT INTO.. (Key) VALUES (SELECT MAX(Key)+1, ...</note></remarks>
        /// <param name="command">Command to execute</param>
        /// <param name="retries">Maximum number of retries</param>
        /// <returns>Number of rows affected. </returns>
        public static int ExecuteNonQueryWithRetry(this SqlCommand command, int retries) {
            for (int failCount = 0;;) {
                try {
                    return command.ExecuteNonQuery();
                }
                catch (SqlException ex) {
                    const int UniqueConstraintViolation = 2627;
                    const int DuplicateKey = 2601;
                    if (++failCount >= retries || 
                        ex.Number == UniqueConstraintViolation ||
                        ex.Number == DuplicateKey)
                        throw;
                }
            }
        }
