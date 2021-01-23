        protected override void Seed(BulkEntities context)
        {
            if (!context.BulkItems.Any())
            {
                var items = Enumerable.Range(0, 100000)
                          .Select(s => new BulkItem
                          {
                              Name = s.ToString(),
                              Status = "asdf"
                          });
                context.BulkInsert(items, 1000);                
            }
        }
