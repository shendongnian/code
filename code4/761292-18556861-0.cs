     List<ItemProduction> NewNames = Enumerable.Range(1, 5).Select(i => new ItemProduction
     {
          Main = string.Empty,
          itemDate = DateTime.UtcNow,
          ItemType = string.Empty,
          productionId = string.Empty,
          Quantity = 0,
          Status = string.Empty
     }).ToList();
