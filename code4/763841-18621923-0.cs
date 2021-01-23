    lstMxa = bdbe.Articles
        .Where(x => x.Count == count)
        .Select(x => new Facade.MixedArticle
        {
            SomePropertyInMixedArticle1 = x.SomeProperty1,
            SomePropertyInMixedArticle2 = x.SomeProperty2,
            // etc.
        })
        .ToList();
