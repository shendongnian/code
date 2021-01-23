    StoredProdResult.Select(spr => new DestinationClass {
      DestinationProperty1 = spr.OriginalColumn1,
      DestinationProperty2 = spr.OriginalColumn4,
      DestinationProperty3 = spr.OriginalColumn2 + " " + spr.OriginalColumn3
     }).ToList()
