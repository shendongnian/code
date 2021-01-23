    int numberOfObjects;
    
    using (var context = new myContext())
    {
        numberOfObjects = context.objects.Count();
    }
    for (int i = 0; i < numberOfObjects; i += 10000)
    {
        using (var context = new myContext())
        {
            var allObjekts = context.objects.OrderBy(s => s.ID)
                .Skip(i)
                .Take(10000)
                .Include("item1")
                .Include("item2")
                .Include("item2.item1")
                .Include("item2.item1.item");
                 
                client.IndexMany(allObjekts);
        }
    }
