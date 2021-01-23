    var query = from p in db.Products 
                    join ph in db.ProductSituationHistory 
                    on p.Id equals ph.ProductId into history
                    let lastHistory = history
                        .OrderByDescending(h=>h.Id)
                        .FirstOrDefault()
                    join s in db.Situation 
                    on lastHistory.SituationId equals s.Id
                    select new ProductGridView
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Situation = s.Description,
                        Manufacturer = p.Manufacturer.Name,
                    };
