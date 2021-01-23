    {
    [Authorize]
    public class ReportsController : Controller
    {
        public ActionResult Reports()
        {
            ReportsPhoneSupportSearchVM model = new ReportsPhoneSupportSearchVM();
            model.ToDate = DateTime.Parse("05/14/2014");
            //do 
            //{
            //    TimeSpan span = DateTime.Now - model.ToDate;
            //    if (span.TotalDays < 2) break;
            //    model.ToDate = model.ToDate.AddDays(14);
            //}
            //while (model.ToDate < DateTime.Now);
            model.FromDate = model.ToDate.AddDays(-14);
            return View(model);
        }
        [HttpPost]
        public ActionResult ReportSearchResults(ReportsPhoneSupportSearchVM model)
        {
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult ReportsPhoneSupportRead([DataSourceRequest] DataSourceRequest request, ReportsPhoneSupportSearchVM model)
        {
            ReportPhoneSupportResultTypedView results = new ReportPhoneSupportResultTypedView();
            string[] userIds = model.UserId.Split(',');
            foreach (string userId in userIds)
            {
                int iUserId = 0;
                if (Int32.TryParse(userId, out iUserId))
                {
                    RetrievalProcedures.FetchReportPhoneSupportResultTypedView(results, model.FromDate, model.ToDate, iUserId);
                }
            }
            var Results = from Reslt in results
                          select new
                          {
                              ActivityDate = Reslt.ActivityDate,
                              Action = Reslt.Action,
                              Assignment = Reslt.Assignment,
                              Description = Reslt.Description,
                              Result = Reslt.Result,
                              ToFrom = Reslt.ToFrom
                          };
            return Json(Results.ToDataSourceResult(request));
            //return Json(Results.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
    }
    }
