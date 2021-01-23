	var hitLeaders = (from s in stats
					  join p in players on s.PlayerID equals p.ID
					  group s by new { s.PlayerID, s.SeasonID } into g
					  select new 
					  { 
					  	 PlayerID = g.Key.PlayerID, 
						 SeasonID = g.Key.SeasonID, 
						 Hits = g.Sum(sum => sum.Hits),
						 AtBats = g.Sum(sum => sum.AtBats),
						 Walks = g.Sum(sum => sum.Walks),
						 Singles = g.Sum(sum => sum.Singles),
						 Doubles = g.Sum(sum => sum.Doubles),
						 Triples = g.Sum(sum => sum.Triples),
						 HomeRuns = g.Sum(sum => sum.HomeRuns),
						 RBIs = g.Sum(sum => sum.RBIs),
						 Runs = g.Sum(sum => sum.Runs),
						 ReachedOnErrors = g.Sum(sum => sum.ReachedOnErrors),
						 SacrificeFlies = g.Sum(sum => sum.SacrificeFlies)
					  }).OrderByDescending(s => s.Hits).Take(5);
