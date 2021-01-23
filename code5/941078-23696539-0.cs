    PropertyInfo[] properties = typeof(Player).GetProperties();
    foreach (XAttribute attribute in playerElement.Attributes())
    {
        PropertyInfo pi = properties.Where(x => x.Name == attribute.Name).FirstOrDefault();
        if (pi != null)
        {
            pi.SetValue(player, attribute.Value);
        }
    }
