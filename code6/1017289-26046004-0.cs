    // TODO: Change the ID type from double to almost anything else. double is a
    // *terrible* type to use for IDs.
    public MenuItem FindMenuItemById(MenuItem item, double id)
    {
        return item.Id == id ? item : item.Children
                                          .Select(x => FindMenuItemById(x, id))
                                          .Where(found => found != null)
                                          .FirstOrDefault();
    }
