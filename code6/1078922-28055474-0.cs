    using System.Data.Entity;
        
    var item = _db.SampleEntity
                       .Include(p => p.NavigationProperty)
                       .Select(p => new YourModel{
                             PropertyOne = p.Something,
                             PropertyTwo = p.NavigationProperty.Any(x => x.Active)
                        })
                       .SingleOrDefault(p => p.Something == true);
