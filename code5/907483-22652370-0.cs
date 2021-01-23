    using (TransactionScope scope = new TransactionScope())
        {
            using (SqlConnection connection1 = new SqlConnection(yourconnectionstring))
            {
               //your commands here
            }
    
            // The Complete method commits the transaction. If an exception has been thrown,
            // Complete is not  called and the transaction is rolled back.
            scope.Complete();
        }
