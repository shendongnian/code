    void AddTest(IPage page) 
    {
        var listElement = page.Sections.First(s => s.Name == "ResultsSection")
            .Widgets.First(w => w.Template.Name == "BannerTemplate")
            .Template.Elements.First(e => e.Name == "List");
    
        listElement.Assetions.Add(new Assestion
        {
            Subject = AssetionSubject.InnerText,
            Predicate = AssetionPredicate.eq,
            Value = "Some banner"
        });
    }
