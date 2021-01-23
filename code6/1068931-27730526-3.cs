        [HttpPost]
        public ActionResult GenerateReport(string param1, int param2)
        {
            // Obviously you apply the parameters as predicates and hit the real database
            Session["ReportData"] = FakeDatabaseData;
            ViewBag.ShowIFrame = true;
            return View();
        }
