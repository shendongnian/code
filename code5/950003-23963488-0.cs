    var permissionsDictionary = new Dictionary<string, List<SelectListItem>>();
    foreach (var user in users) {
        var listItems = new List<SelectListItem>();
        listItems.Add(new SelectListItem() {
            //Do your stuff!
        });
        permissionsDictionary.Add(user.Name, listItems);
    }
    model.Permissions = permissionsDictionary;
