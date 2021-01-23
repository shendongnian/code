    List<Task> tasks = new List<Task>();
    foreach (var item in list)
    {
       ObjectContext oContext = new ObjectContext("MyConnection");
       Task t = Task.Factory.StartNew(() =>
       {
          this.Update(item,oContext);
       });
       tasks.Add(t);
    }
    
    Task.WaitAll(tasks.ToArray());
