    public PartialViewResult List()
    {
        var timeComparison = DateTime.Today.AddDays(-30);
        var query = repository.Members.Where(p => p.Entry.Select(e => e.TimeStamp).FirstOrDefault() <= timeComparison).OrderByDescending(p => p.Entry.Count));
        //return PartialView(repository.Members);
        return PartialView(query);
    }
