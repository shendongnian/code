    XElement user = doc.Descendants("User")
                       .FirstOrDefault(user => 
                          user.Attribute("Name").Value == "ServerManager");
    
    string directory = "some directory";
    if (user != null)
    {
        XElement option = new XElement("Option", 
                              new XAttribute("Name", "Test"), 
                              new XText("1"));
    
        XElement permission = user.Descendants("Permission")
                                  .FirstOrDefault(perm => 
                                  perm.Attribute("Dir").Value == directory);
        if (permission == null)
        {
            XElement permissions = user.Element("Permissions");
            if (permissions == null)
                user.Add(permissions = new XElement("Permissions"));
            permissions.Add(permission = new XElement("Permission",
                new XAttribute("Dir", directory)));
        }
        permission.Add(option);
    }
                         
