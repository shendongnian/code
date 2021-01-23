     decimal sumOfTransaction = 5m;
     using(TransactionScope scope = new TransactionScope())
     using(SqlConnection cn = new SqlConnection(connectionString))
     {
        string upd1 = @"UPDATE Table1 SET currentMoney = currentMoney + @amount
                        WHERE accountNo=@account";
        string upd1 = @"UPDATE Table1 SET currentMoney = currentMoney - @amount
                        WHERE accountNo=@account";
        cn.Open();
        using(SqlCommand cmd = new SqlCommand(upd1, cn);
        {
            cmd.Parameters.AddWithValue("@amount", sumOfTransaction);
            cmd.Parameters.AddWithValue("@account", receivingAccount);
            cmd.ExecuteNonQuery();
            cmd.Parameters["@account"].Value = debitAccount);
            cmd.ExecuteNonQuery();
        }
        scope.Complete();
     }
