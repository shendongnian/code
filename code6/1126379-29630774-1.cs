     List<lbResults> lb = new List<lbResults>
     {
          new lbResults{ Name="John", Assess = 1, Score=90},
          new lbResults{ Name="John", Assess = 2, Score=88},
          new lbResults{ Name="John", Assess = 3, Score=67},
          new lbResults{ Name="Steve", Assess = 1, Score=98},
          new lbResults{ Name="Steve", Assess = 2, Score=90},
     };
    var results = lb.GroupBy(l => l.Name)
                    .Select(g => new 
                            { 
                              Name = g.Key, 
                              Assess = g.Max(gr => gr.Assess), 
                              Score = g.Average(gr => gr.Score) 
                            });
