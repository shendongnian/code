    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
    {
      using (var dbConn = GetDbFactory().Create())
      {
        foreach (MyDTO dto in dtoList)
        {
            var tableDAO= new TableDAO(dbConn);
            MyEntity entity = new MyEntity()
            {
                Field1 = dto.Field1,
                Field2 = dto.Field2
            };
            tableDAO.AddOrUpdate(entity);
         }
      }
         // Commit changes
      scope.Complete();
    }
