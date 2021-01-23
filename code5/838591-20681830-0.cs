    public static XElement ToXml(this User user)
    {
        if (user == null)
        {
            throw new ArgumentException("User can not be null.");
        }
        XElement userElement = new XElement("User");
        userElement.Add(new XElement("ID", user.ID));
        userElement.Add(new XElement("Name", user.Name));
        userElement.Add(new XElement("Location", user.Location));
        userElement.Add(new XElement("UserAgeGroup", user.UserAgeGroup));
        return userElement;
    }
    public static string ToXml(this UserCollection userCollection)
    {
        if (userCollection == null)
        {
            throw new ArgumentException("UserCollection can not be null.");
        }
        XElement userCollectionElement = new XElement("UserCollection");
        userCollectionElement.Add(new XElement("UserGroup", userCollection.UserGroup));
        userCollectionElement.Add(new XElement("Users", 
                                               userCollection.Users.Select(x => new XElement("User", x.ToXml()));
        return userCollectionElement;
    }
