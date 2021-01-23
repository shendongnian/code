    IEnumerable<Comment> GetChild(int id)
    {
        return table.Where(x => x.ParentID == id || x.Id== id)
                    .Union(table.Where(x => x.ParentID == id)
                                .SelectMany(y => GetChild(y.Id))
        );
    }
