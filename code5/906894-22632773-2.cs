       /// <summary>
        /// Gets the raw as a String.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns>The response</returns>
        protected String FindRawResponse(String sql)
        {
            // provide the data source and the SQL needed to find the products
            var postData = new { dataSource = this.DataSource, query = sql };
            // Grab the response and wrap as a stream
            String response = this.Client.Request(String.Format("{0}{1}", this.EndPoint, "/GetSql"), GetQueryString(postData));
            return response;
        }
