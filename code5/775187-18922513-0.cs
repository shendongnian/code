    private void remove(MyObj obj)
    {
        var itemToRemove = list.Where(x => x.fileName == obj.fileName);
        if (itemToRemove.Any())
            list.Remove(itemToRemove.First());
    }
