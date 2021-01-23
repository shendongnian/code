     List<ItemProduction> items = Enumerable.Range(1, 5).Select(i => new ItemProduction
     {
          Main = string.Empty,
          ItemDate = DateTime.UtcNow,
          ItemType = string.Empty,
          ProductionId = string.Empty,
          Quantity = 0,
          Status = string.Empty
     }).ToList();
