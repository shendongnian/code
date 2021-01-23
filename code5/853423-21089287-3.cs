    var menus = new List<Menu>();
    
    foreach (XmlNode menuNode in nodeList)
    {
         var groupName = new List<Group>(); // create list here
    
         foreach (XmlNode childNode in menuNode)
            groupName.Add(new Group { name = childNode.Attributes["name"].Value });
                     
         menus.Add(new Menu {
            name = menuNode.Attributes["name"].Value,
            group = groupName
         });  
    }
