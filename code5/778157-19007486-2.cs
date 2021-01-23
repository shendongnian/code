    public PartialViewResult GetPartial()
        {
            var viewModel = (from P in db.Projects
                             join R in db.Reports on P.ProjectTitle equals R.ReportProjectID into ps
                             from R in ps.DefaultIfEmpty()
                             select new MyViewModel { Project = P, Report = R });
            return PartialView("_Partial1", viewModel);
        }
