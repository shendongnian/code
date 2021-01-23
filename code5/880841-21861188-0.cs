    public void SearchBooks(params Funct<Book, bool>[] predicates)
    {
        var query = AllBooks.AsEnumerable();
        foreach(var p in predicates)
            query = query.Where(p);
        SelectedBooks = query.ToList();
    }
