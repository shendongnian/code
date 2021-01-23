    var toBeSerialized = myBlueprints
        .GroupBy(bp => new {bp.Name, bp.Approach})
        .Select(bpg => new
        {
            name = bpg.Key.Name,
            approach = bpg.Key.Approach,
            options = new
            {
                begin = bpg.Min(bp => bp.Value),
                end = bpg.Max(bp => bp.Value)
            }
        });
