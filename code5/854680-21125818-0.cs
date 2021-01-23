    public String Get(int id)
    {
        var item = platypi.Find(p => p.Id == id);
        return item == null ? string.Empty : item.Name;
    }
