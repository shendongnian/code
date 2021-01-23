    var compdata = from result in db.Results
                   where result.Complete == true
                   group result by new
                   {
                       result.CompetitorId,
                       result.Competitor.Name,
                       result.Competitor.Category,
                       result.Competitor.Gender,
                   }
                   into resultsGroup
                   select new Game
                   {
                       CompetitorId = resultsGroup.Key.CompetitorId,
                       Name = resultsGroup.Key.Name,
                       Category = resultsGroup.Key.Category,
                       Gender = resultsGroup.Key.Gender,
                       Score = resultsGroup.OrderByDescending(s => s.Activity.Value).Take(5).Sum(s => s.Activity.Value)
                   };
