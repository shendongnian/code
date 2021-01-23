    public virtual MvcMailMessage AdminNotification()
    {
        string[] userRoles = Roles.GetUsersInRole("Admin");
        IEnumerable<string> emails =
            userRoles.Select(userName => Membership.GetUser(userName, false))
                     .Select(user => user.Email);
        var message = new MvcMailMessage {Subject = "AdminNotification", ViewName = "AdminNotification"};
        foreach (string email in emails)
        {
            message.To.Add(email);
        }
        return message;
    }
