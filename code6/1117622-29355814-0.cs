        [OutputCache(NoStore = true, Location = OutputCacheLocation.Client, Duration = 10)]
        public ActionResult UpdateTotals()
        {
            JobController j = new JobController();
            ViewBag.JobCount = j.JobCount();
            ProductController p = new ProductController();
            ViewBag.ProductCount = p.ProductCount();
            return PartialView("UpdateTotals");
        }
