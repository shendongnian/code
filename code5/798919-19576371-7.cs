        #region operation: Multi-Result Set
        /// <summary>
        /// Perform a multi-results set query
        /// </summary>
        /// <param name="sql">An SQL builder object representing the query and it's arguments</param>
        /// <returns>A GridReader to be queried</returns>
        public GridReader QueryMultiple(Sql sql)
        {
            return QueryMultiple(sql.SQL, sql.Arguments);
        }
        /// <summary>
        /// Perform a multi-results set query
        /// </summary>
        /// <param name="sql">The SQL query to be executed</param>
        /// <param name="args">Arguments to any embedded parameters in the SQL</param>
        /// <returns>A GridReader to be queried</returns>
        public GridReader QueryMultiple(string sql, params object[] args)
        {
            OpenSharedConnection();
            GridReader result = null;
            var cmd = CreateCommand(_sharedConnection, sql, args);
            try
            {
                var reader = cmd.ExecuteReader();
                result = new GridReader(this, cmd, reader);
            }
            catch (Exception x)
            {
                if (OnException(x))
                    throw;
            }
            return result;
        }
        #endregion
