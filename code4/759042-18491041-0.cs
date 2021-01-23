    var query = groups.Select( g => {
        String id = g.Attributes["id"].Value;
        String title = g.Attributes["title"].Value;
        return new Group(id, title);
    });
    List<Group> groupsCollection = new List<Group>(query);
