    m => m.Messages.AsQueryable().Where(predicate)  // IQueryable.Where accepts Expressions
    
    // complete invocation
    IEnumerable <Results> GetByPredicate(Func<Message, bool> predicate) {
      DataContext.Threads.Where(<some criteria>)
                         .Select(m => m.Messages.AsQueryable().Where(predicate));
    }
