    public void SearchBooks(params Func<Book, bool>[] predicates)
    {
        var query = AllBooks.AsEnumerable();
        foreach(var p in predicates)
            query = query.Where(p);
        SelectedBooks = query.ToList();
    }
