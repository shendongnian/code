    private static SelectListItem[] _UsersList;
    /// <summary>
    /// Returns a static category list that is cached
    /// </summary>
    /// <returns></returns>
    public SelectListItem[] GetUsersList()
    {
        if (_UsersList == null)
        {
            var users = repository.GetAllUsers().Select(a => new SelectListItem()
             {
                 Text = a.USER_NAME,
                 Value = a.USER_ID.ToString()
             }).ToList();
             users.Insert(0, new SelectListItem() { Value = "0", Text = "-- Please select your user --" });
            _UsersList = users.ToArray();
        }
        // Have to create new instances via projection
        // to avoid ModelBinding updates to affect this
        // globally
        return _UsersList
            .Select(d => new SelectListItem()
        {
             Value = d.Value,
             Text = d.Text
        })
         .ToArray();
    }
