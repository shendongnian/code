        public PartialViewResult List()
        {
            var timeComparison = DateTime.Today.AddDays(-30).Day;
            var query = repository.Members
                      .OrderBy(m => m.Entry.Where(e => e.TimeStamp.Day <= timeComparison).Count());
            return PartialView(query);
        }
