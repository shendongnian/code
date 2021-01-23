    using (TransactionScope scope = new TransactionScope())
        {
            using (SqlConnection connection1 = new SqlConnection(connectString1))
            {
                Action1(connection1);
                Action2(connection1);
                Action3(connection1);
                Action4(connection1);
                Action5(connection1);
                Action6(connection1);
            }
            // The Complete method commits the transaction. If an exception has been thrown, 
            // Complete is not  called and the transaction is rolled back.
            scope.Complete();
        }
