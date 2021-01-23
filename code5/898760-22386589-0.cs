        while (objRead.Read())
        {
            ListViewItem list = new ListViewItem(basa["FID"].ToString());
            list.SubItems.Add(objRead["FullName"].ToString());
            list.SubItems.Add(objRead["Age"].ToString());
            list.SubItems.Add(objRead["Gender"].ToString());
            list.SubItems.Add(objRead["Relationship"].ToString());
            list.SubItems.Add(objRead["SkillnOccupation"].ToString());
            lvlist.Items.Add(list);
        }
