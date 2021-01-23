    return Populate(x =>
        {
            x.Subject = "AdminNotification";
            x.ViewName = "AdminNotification";
            emails.ForEach(user => x.To.Add(user.Email));
        });
