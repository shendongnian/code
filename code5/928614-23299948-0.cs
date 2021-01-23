    Task t = new Task { Detail = ...  };
    
    using (var context = new MyContext())
    {
        context.Tasks.Add(t);
        context.SaveChanges();
    }
