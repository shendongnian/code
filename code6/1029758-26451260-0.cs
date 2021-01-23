        public ActionResult Test()
        {
            var data = TestData().ToArray();
            return View("ReportData", new ReportDataViewModel(data, ""));
        }
