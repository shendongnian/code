    List<User> users = new List<User>();
    List<Venue> venues = new List<Venue>();
    foreach (string key in deserializedObject.Objects.Keys)
    {
        if (key.StartsWith("user", StringComparison.InvariantCultureIgnoreCase))
        {
            users.Add(new User { Uid = deserializedObject.Objects[key].uid });
        }
        if (key.StartsWith("venue", StringComparison.InvariantCultureIgnoreCase))
        {
            venues.Add(new Venue { Id = deserializedObject.Objects[key].id });
        }
    }
