    // adding by index
    menuList[0].Sections[0].Items.Add(new Item() { .. init .. });
    
    // keep a reference to a section
    Section dinner = new Section() { .. init .. };
    dinner.Items.Add(new Item() { .. init ..});
    dinner.Items.Add(new Item() { .. init ..});
    menu.Sections.Add(dinner);
