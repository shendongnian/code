    using (var session = sessionFactory.OpenSession())
    {
        var questionsForSurvey = session.Query<SiteSurveyQuestion>()
            .Where(x => x.Site.Id == 1 && x.Survey.Id == 1)
            .ToArray()
            .Select(s => s.Clone() as SiteSurveyQuestion);
    }
