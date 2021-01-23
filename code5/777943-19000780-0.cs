    foreach (Actor line in ActorArrayList)
        {
            cboActor.Items.Add(new ListItem( line.Name ,line.ID)); //as second part you may enter the ID of the object so you can use it at a later time
        }
    }
