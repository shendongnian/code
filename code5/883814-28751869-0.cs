    private async Task<List<RelatedPageModel>> GetRelatedCaseStudies(CaseStudy casestudy, bool archived)
    {
    return await Db.Pages.OfType<CaseStudy>()
            .Where(r => r.Client == casestudy.Client && r.Id != casestudy.Id)
            .Where(x => x.IsArchived == archived)
            .Include(r => r.Media)
            .Take(3)
            .Project().To<RelatedPageModel>()
            .ToListAsync();
    }
