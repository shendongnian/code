    var categoryTasks = Categories.Find<Category>(x => x.CategoryName == catName)
                         .Project(Builders<Category>.Projection
                                                    .Include("tasks.name")
                                                    .Exclude("_id"))
                         .ToListAsync()
                         .Result;   
    var taskNames = categoryTasks.Tasks.Select(task => task.Name).ToList();
