        public static void Logging()
        {
            var opt = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress, opt))
            {
                using (SqlConnection conn2 = new SqlConnection(connectString1))
                {
                    conn2.Open();
                    SqlCommand command2 = new SqlCommand("insert into ErrorLog(AppURL,Title,Message) values ('a','b','c')", conn2);
                    int aff2 = command2.ExecuteNonQuery();
                    scope.Complete();
                }
            }
        }
