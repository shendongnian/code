    for (int i = 0; i < 500000; i+=1000)
    {
        using (var db = new DbContext())
        {
            var chunk = largeListOfAddress.Take(1000).Select(a=> new Address{ Id = a.Id});
            db.Address.RemoveRange(chunk);
            db.SaveChanges();
        }
    }
