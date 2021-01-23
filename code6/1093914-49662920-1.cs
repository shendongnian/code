    public Task<List<MyBigObjectItem>> GetMyBigObjectItemsAsync(int ownerId, CancellationToken cancellationToken = default(CancellationToken))
    {
        return (
            from obj in DataContext.MyBigObject
            join object1 in DataContext.SomeObject1 on obj.Id equals object1.ObjectId into object1items
            join object2 in DataContext.SomeObject2 on obj.Id equals object2.ObjectId into object2items
            where obj.OwnerId = ownerId
            orderby obj.Name
            select new MyBigObjectItem
            {
                Id = obj.Id,
                Name = obj.Name,
                TypeId = obj.TypeId,
                IsFoo = obj.IsFoo,
                IsBar = obj.IsBar,
                HasObject1 = object1items.Any(),
                HasObject2 = object2items.Any()
            }
        )
        .Decompile() // Line to add
        .ToListAsync(cancellationToken);
    }
