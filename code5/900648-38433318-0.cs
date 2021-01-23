    using (var db = dbFactory.Open())
    using (var tran = db.OpenTransaction())
    {
      // operations on db...
      using (var nestedDb = dbFactory.Open())
      using (var nestedTran = nestedDb.OpenTransaction())
      { // .Rollback/.Commit as required }
    }
