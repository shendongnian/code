    var query = ctx.Portal_SurveyRecommendations
        .Where(c => c.CustNum == insuredNumber);
    if(surveyLocationNumber != -1)
        query = query.Where(l => l.LocationKey == surveyLocationNumber);
    if(dateIssuedFilter != DateTime.MinValue)
        query = query.Where(di => di.DateRecIssued == null
                               || di.DateRecIssued.Value > dateIssuedFilter);
    if(dateCompletedFilter != DateTime.MinValue)
        query = query.Where(dc => dc.DateRecComplete == null
                               || dc.DateRecComplete.Value > dateCompletedFilter);
    var surveys = query.OrderBy(o => o.ReportKey).ThenBy(o => o.RecNumKey).ToList();
