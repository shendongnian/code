    var menus = new List<Menu>();
    
    foreach (XmlNode menuNode in nodeList)
    {                
         Menu menu = new Menu();  // create menu inside loop
         menu.name = menuNode.Attributes["name"].Value;
         menu.group = new List<Group>(); // create list here
    
         foreach (XmlNode childNode in menuNode)
            menu.group.Add(new Group { name = childNode.Attributes["name"].Value });
                     
         menus.Add(menu);  
    }
