    using (var session = sessionFactory.OpenSession())
    {
        var questionsForSurvey = session.Query<SiteSurveyQuestion>()
            .Where(x => x.Site.Id == 1 && x.Survey.Id == 1)
            .ToArray();
        var result = new List<SiteSurveyQuestionDTO>();
        foreach(var s  in questionsForSurvey)
        {
           // here we can touch all the inner properties and collections
           // so NHibernate will load all needed data in batches
           var dto = s.doSomething();
           result.Add(dto);
        }
    }
