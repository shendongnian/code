    public JsonResult EmployeeJqGridDataRequested()
    {
          var bugGridModel = new BugJqGridViewModel();
          var db = new bugContext();
          var bugs = from b in db.Bugs
                     join bt in db.BugTypes on b.BugTypeId equals bt.BugTypeId
                     join bs in db.BugStati on b.BugStatusId equals bs.BugStatusId
                     select new { b.BugId, bt.BugTypeName, bs.BugStatusName,b.DateReported,b.Description };
          return bugGridModel.Grid.DataBind(bugs);
    }
