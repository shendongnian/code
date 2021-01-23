    var query = (from c in db.tblGroups
                 select new
                 { c.GroupId,
                    c.Name
                 })
                 .ToList();
    
    GroupcomboBox.Items.Add("Select ----");
    foreach (var item in query)
    {
        GroupcomboBox.Items.Add(item);
    }
    
    GroupcomboBox.DisplayMember = "Name";
    GroupcomboBox.ValueMember = "GroupId";
