    protected override void Seed(DBContextIMD context)
    {
        using (MyDBContext DBContext = new MyDBContext(true))
        {
            DBContext.IdentityInsert<SomeEntityType>(true);
            DBContext.ABCStatusList.Add(new SomeEntityType() { ID = 0, SomeProperty= @"Default" });
            DBContext.SaveChanges();
            DBContext.IdentityInsert<ABCStatus>(false);
        }
    }
