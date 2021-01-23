    List<Group> groupsCollection = new List<Group>();
    groups.ForEach(g => {
        String id = g.Attributes["id"].Value;
        String title = g.Attributes["title"].Value;
        groupsCollection.Add(new Group(id, title));
    } );
