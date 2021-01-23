    var entity= new Model
    {
        GoDate = (DateTime?) null
    }
    DataContext.Models.Add(entity);
    DataContext.SaveChanges();
