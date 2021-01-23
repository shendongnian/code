    protected override void Seed(DBContextIMD context)
    {
        bool HasDefaultRecord;
        HasDefaultRecord = false;
        DBContext.ABCStatusList.Where(DBEntity => DBEntity.ID == 0).ToList().ForEach(DBEntity =>
        {
            DBEntity.ABCStatusCode = @"Default";
            HasDefaultRecord = true;
        });
        if (HasDefaultRecord) { DBContext.SaveChanges(); }
        else {
            using (var dbContextTransaction = DBContext.Database.BeginTransaction()) {
                try
                {
                    DBContext.IdentityInsert<ABCStatus>(true);
                    DBContext.ABCStatusList.Add(new ABCStatus() { ID = 0, ABCStatusCode = @"Default" });
                    DBContext.SaveChanges();
                    DBContext.IdentityInsert<ABCStatus>(false);
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    // Log Exception using whatever framework
                    Debug.WriteLine(@"Insert default record for ABCStatus failed");
                    Debug.WriteLine(ex.ToString());
                    dbContextTransaction.Rollback();
                    DBContext.RollBack();
                }
            }
        }
    }
