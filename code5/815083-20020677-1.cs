    XElement user = doc.Descendants("User")
                       .FirstOrDefault(user => 
                          user.Attribute("Name").Value == "ServerManager");
    
    string directory = "some directory";
    string optionName = "FileRead";
    int optionSetting = 1;
    if (user != null)
    {
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
        XElement option = permission.Elements("Option")
            .FirstOrDefault(op => op.Attribute("Name").Value == optionName);
        if (option == null)
            permission.Add(option = new XElement("Option", 
                 new XAttribute("Name", optionName)));
        option.Value = optionSetting.ToString();
    }
                         
