    public bool HasChanges(MyEntity myentity)
    {
      return this.ChangeTracker.Entries().Any(e => e.Entity == myentity &&
        (this.Entry(myentity).GetDatabaseValues().GetValue<DateTimeOffset>("aDateField") != myentity.aDateField)
      );
    }
