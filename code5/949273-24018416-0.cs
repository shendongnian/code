    public class Score_TopScoringIndex : AbstractIndexCreationTask<Score, Score>
    {
         public Score_TopScoringIndex()
         {
            Map = docs => from doc in docs
                      select new
                           {
                               Score = doc.Score,
                               ID = doc.ID,
                               Date = doc.Date
                           };
    
            Reduce = results => from result in results
                            group result by result.ID into g
                            select new 
                            {
                               Score = g.First().Score,
                               ID = g.Key,
                               Date = g.First().Date
                            };
    
            Sort(x=>x.Score, SortOptions.Int);
         }
    }
