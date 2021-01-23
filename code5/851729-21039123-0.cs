    using(var scope = new TransactionScope())
    {
       using(var conn = new SqlConnection(/*...*/))
       {
          //As many nested commands, etc, using the above connection.
          //but don't need to create a SqlTransaction object nor
          //in any way reference the scope variable
       }
       scope.Complete();
    }
