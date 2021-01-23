    var toBeSerialized = myBluePrints
       .GroupBy(bp => new { bp.Name, bp.Approach })
       .Select(bpg => new { 
            name = bpg.Key.Name, 
            approach = bpg.Key.Approach, 
            options = new { 
                begin: bpg.Max(bp => bp.Value),
                end: bpg.Min(bp => bp.Value)
            }  
        })
