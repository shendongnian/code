    public IQueryable<YourClass> func(int param1) {
      using(var context=DaatabaseFramework.GetContext()) {
        return context.MyTable.Where(_=>_.Param1==Param1);
      }
    }
