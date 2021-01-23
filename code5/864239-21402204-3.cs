    foreach (var li in ListBox1.Items.Cast<ListItem>().Where(x => x.Selected))
    {
        var user = Membership.GetUser(li.Value);
        if (user != null)
        {
            user.IsLockedOut = false;
            Membership.UpdateUser(user);
        }
    }
