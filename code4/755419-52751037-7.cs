    private static SelectListItem[] _UserRolesList;
    /// <summary>
    /// Returns a static category list that is cached
    /// </summary>
    /// <returns></returns>
    public SelectListItem[] GetUserRolesList()
    {
        if (_UserRolesList == null)
        {
            var userRoles = repository.GetAllUserRoles().Select(a => new SelectListItem()
             {
                 Text = a.UserRole,
                 Value = a.UserRoleId.ToString()
             }).ToList();
             userRoles.Insert(0, new SelectListItem() { Value = "0", Text = "-- Please select your user role --" });
            _UserRolesList = userRoles.ToArray();
        }
        // Have to create new instances via projection
        // to avoid ModelBinding updates to affect this
        // globally
        return _UserRolesList
            .Select(d => new SelectListItem()
        {
             Value = d.Value,
             Text = d.Text
        })
         .ToArray();
    }
