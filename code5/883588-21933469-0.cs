            /// <summary>
            /// Gets a list of Customers by name (with paging)
            /// </summary>
            /// <param name="oSageDatabase">The Sage database to query</param>
            /// <param name="startIndex">The start index</param>
            /// <param name="endIndex">The end index</param>
            /// <param name="filter">The filter</param>
            /// <returns>List of suppliers</returns>
            public static List<SLCustomerAccount> GetCustomersByAccountNumber(SageDatabase oSageDatabase, int startIndex, int endIndex, string filter)
            {
                try
                {
                    string query = @"
                    SELECT * 
                    FROM
                    (
                        SELECT [SLCustomerAccount].*, 
                               ROW_NUMBER() OVER (ORDER BY [SLCustomerAccount].[CustomerAccountNumber]) AS RowNumber
                        FROM   [SLCustomerAccount] 
                        LEFT JOIN [SLCustomerLocation]
                        ON [SLCustomerAccount].[SLCustomerAccountID]
                        = [SLCustomerLocation].[SLCustomerAccountID]
                        AND [SLCustomerLocation].[SYSTraderLocationTypeID]=0
                        WHERE  [AccountIsOnHold]=0
                        AND    [CustomerAccountNumber] + ' ' + [CustomerAccountName] + ' ' + [CustomerAccountShortName] + ' ' + ISNULL([SLCustomerLocation].[PostCode], '') LIKE @Filter
                    ) as p
                    WHERE p.RowNumber BETWEEN @StartIndex AND @EndIndex
                    ";
    
                    using (SqlCommand oSqlCommand = new SqlCommand(query))
                    {
                        oSqlCommand.Parameters.AddWithValue("@StartIndex", startIndex + 1);
                        oSqlCommand.Parameters.AddWithValue("@EndIndex", endIndex + 1);
                        oSqlCommand.Parameters.AddWithValue("@Filter", String.Format("%{0}%", filter));
    
                        using (DataTable dtSupplier = DataTier.ExecuteQuery(oSageDatabase.ConnectString, oSqlCommand))
                        {
                            return (from DataRow dr
                                    in dtSupplier.Rows
                                    select new SLCustomerAccount(dr, oSageDatabase)).ToList();
                        }
                    }
    
                }
                catch (Exception)
                {
                    throw;
                }
            }
