using (var  dataContext = new SchoolMSDbContext())
{
  using (var trans = dataContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
  {
    try
    {
      // your query
      trans.Commit();
    }
    catch (Exception ex)
    {
      trans.Rollback();
      Console.WriteLine(ex.InnerException);
    }
  }
}
