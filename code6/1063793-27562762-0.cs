    using (var db = new ApplicationDbContext())
    {
       var empFromDb = db.Employees.Include(x => x.WorkingSites).First(x => x.Id == _employeeId);
       empFromDb.WorkingSites.Add(workingSiteToEnd);
       db.SaveChanges();
       //Act
       ServiceFactory.CreateEmployeeService().EndWorkingSitePeriod(workingSiteToEnd, db);
       //Assert
       var workingSiteFromDb = db.WorkingSites.First(x => x.Id == workingSiteToEnd.Id);
       Assert.AreEqual(DateTime.Now.AddDays(-1).Date, workingSiteFromDb.WorksUntil.Date);
    }
    private void EndWorkingSitePeriod(int workingSiteId, ApplicationDbContext db)
    {
        var workingSiteFromDb = db.WorkingSites.Include(x => x.Employee).First(x => x.Id == workingSiteId);
        workingSiteFromDb.EndPeriod();
        db.SaveChanges();
    }
    // if you need it public, then use this too
    public void EndWorkingSitePeriod(int workingSiteId)
    {
        using (var db = new ApplicationDbContext()) 
        {
           EndWorkingSitePeriod(workingSiteId, db);
        }
    }
