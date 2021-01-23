    public IEnumerable<SelectListItem> ToSelectListItem()
    {
        return dbSet.Select(bc => new SelectListItem()
                                       {
                                         Text = bc.Name,
                                         Value = bc.Id.ToString()
                                       })
                    .ToArray();
    }
