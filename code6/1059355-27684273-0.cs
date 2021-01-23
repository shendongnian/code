internal class Program
{
    private static void Main()
    {
        string connString = "data source=.;initial catalog=Test;integrated security=True;persist security info=True";
        string tokenFile = @"c:\Temp\token.txt";
        Transaction transaction = null;
        bool isChild = false;
        if (File.Exists(tokenFile))
        {
            isChild = true;
            string tokenString = File.ReadAllText(tokenFile);
            byte[] token = Convert.FromBase64String(tokenString);
            transaction = TransactionInterop.GetTransactionFromTransmitterPropagationToken(token);
        }
        using (var parentTxCompleteEvent = new ManualResetEventSlim(!isChild))
        {
            using (var transactionScope = transaction != null ? new TransactionScope(transaction) : new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 15, 0)))
            {
                var curr = Transaction.Current;
                if (!isChild)
                {
                    byte[] transactionBytes = TransactionInterop.GetTransmitterPropagationToken(curr);
                    string tokenString = Convert.ToBase64String(transactionBytes);
                    File.WriteAllText(tokenFile, tokenString);
                }
                else
                {
                    transaction.TransactionCompleted += (sender, e) => parentTxCompleteEvent.Set();
                }
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        Console.WriteLine("Enter id and value");
                        cmd.CommandText = "INSERT INTO KeyValue(Id, Value) VALUES (@1, @2)";
                        cmd.Parameters.Add(new SqlParameter("@1", Console.ReadLine()));
                        cmd.Parameters.Add(new SqlParameter("@2", Console.ReadLine()));
                        cmd.ExecuteNonQuery();
                    }
                }
                transactionScope.Complete();
                Console.WriteLine("Dispose");
                Console.ReadLine();
            }
            parentTxCompleteEvent.Wait();
        }
    }
}
  [1]: http://msdn.microsoft.com/en-us/library/system.transactions.transaction.transactioncompleted.aspx
  [2]: http://msdn.microsoft.com/en-us/library/system.threading.manualreseteventslim.aspx
