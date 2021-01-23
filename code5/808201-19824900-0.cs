    using(var scope = new TransactionScope(
            TransactionScopeOption.RequiresNew,
            new TransactionOptions() {
                    IsolationLevel = IsolationLevel.ReadCommitted
                })) {
        context.Authors.Add(newauthor);
        context.SaveChanges();
        newbook.AuthorID = newauthor.ID
        context.Books.Add(newbook);
        context.SaveChanges();
        scope.Complete();
    }
