    public ActionResult ViewReport(int? id, string memberID, int month, int year)
     {
                var task = new ViewReportTask(); 
                return View(task.BuildViewModel(id, memberID, month, year));
      }
