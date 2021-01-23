    class LotteryDTO
    {
      public string Name { get; set; }
      public string CreatedBy { get; set; } 
      ...
    }
    IQueryable<LotteryDTO> result = db.LotteryOffers
                                .Where(...)
                                .SelectMany(...)
                                .Select(...)
                                .GroupBy(...)
                                .Select(g => new LotteryDTO {
                                   Name = g.Key.Name,
                                   CreatedBy = g.Key.CreatedBy,
                                   ...    
                                });
