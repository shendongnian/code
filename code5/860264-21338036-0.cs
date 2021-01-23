        private kontrollsystemEntities db = new kontrollsystemEntities();
        //
        // GET: /Report/
        public ActionResult Index()
        {
            IQueryable<udf_GetReportsByController_Result> result = db.udf_GetReportsByController(User.Identity.Name);
            return View(result.ToList());
        }
    }
}
