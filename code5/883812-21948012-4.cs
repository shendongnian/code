    public async Task<ActionResult> Details(string slug)
    {
        Func<Task<ActionResult>> doAsync = async () =>
        {
            var item = await Db.Pages.OfType<CaseStudy>()
                     .WithSlug(slug)
                     .FirstOrDefaultAsync();
            if (item == null)
            {
                return HttpNotFound();
            }
            var related = await Db.Pages.OfType<CaseStudy>()
                   .Where(r => r.Client == item.Client && r.Id != item.Id)
                   .Where(r => !r.IsArchived)
                   .Include(r => r.Media)
                   .Take(3)
                   .Project()
                   .To<RelatedPageModel>()
                   .ToListAsync();
            var archived = await Db.Pages.OfType<CaseStudy>()
                    .Where(r => r.Client == item.Client && r.Id != item.Id)
                    .Where(r => r.IsArchived)
                    .Take(3)
                    .Project()
                    .To<RelatedPageModel>()
                    .ToListAsync();
            ViewData.Model = new DetailPageModel<CaseStudy>()
            {
                Item = item,
                RelatedItems = related,
                ArchivedItems = archived
            };
            return View();
        };
        using (var staThread = new Noseratio.ThreadAffinity.ThreadWithAffinityContext(
            staThread: false, pumpMessages: false))
        {
            return await staThread.Run(() => doAsync(), CancellationToken.None);
        }
    }
