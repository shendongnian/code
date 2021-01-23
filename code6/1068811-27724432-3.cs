    public ActionResult Browse()
    {
        using (CLASSContext context = new CLASSContext())
        {
            List<QuestionGroupViewModel> questionGroupsWithLinks = context.QuestionGroup
                .Include(qg => qg.Questions.Select(q => q.Answers))
                .Where(qg => qg.QuestionGroupID == 128)
                .Select(x => new QuestionGroupViewModel
                 {
                     Id = x.Id,
                     // ...etc.
                 })
                .ToList();
            return View("Browse", questionGroupsWithLinks);
        }
    }
