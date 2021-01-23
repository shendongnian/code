    // Let me suppose you're using EF to store some data
    using (var context = new DatabaseContext())
    {
        foreach (var li in ListBox1.Items.Cast<ListItem>().Where(x => x.Selected))
        {
            // I assume you have user ID (as it's name) in the Value property
            // of each ListItem in your ListBox
            string userName = li.Value;
    
            var user = context.Users.FirstOrDefault(x => x.Name == userName);
    
            // This is not redundant, user may even be deleted in another session
            if (user != null)
            {
                // Do changes you need
                user.HasBeenSelected = true;
            }
        }
        
        // We're done, apply changes you made
        context.SaveChanges();
    }
