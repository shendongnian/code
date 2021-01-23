    using (var context = new TestDbContext())  
    {
        //1. Load a Question from Db
        var question = context.Questions
                              .Include("TransQuestions")                        
                              .Where(/*some conditions*/)
                              .AsNoTracking() 
                              .FindFirstOrDefault();  
        //2. Do some changes with question and its childs
        .... 
        //3. Update Db values with changed question values
        context.UpdateGraph(question, map => map.OwnedCollection(p => p.TransQuestion));
        context.SaveChanges();
    }
