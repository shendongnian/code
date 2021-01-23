    public IEnumerable<StoreModel> GetStores()
    {
        using (var db = new MyDbContext())
        {
            var entities = db.Stores;
            return entities.Select(x => new StoreModel
            {
                Id = x.Id,
                Title = x.Title,
                Owner = x.Owner,
                Books = x.Books.Select(y => new BookModel
                {
                    Id = y.Id,
                    Title = y.Title,
                    StoreId = x.Id,
                }),
            });
        }
    }
