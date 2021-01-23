    public int SearchOf(First pattern)
    {
        return SearchOf(pattern.Id, firstItems);
    }
    public int SearchOf(Second pattern)
    {
        return SearchOf(pattern.Id, secondItems);
    }
    private static int SearchOf(int id, IEnumerable<IIdent> searched)
    {
        int index = 0;
        foreach (var ident in searched)
        {
            if (ident.Id == id)
                return index;
            index++;
        }
        return -1;
    }
