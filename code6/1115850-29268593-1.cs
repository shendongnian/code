    var userId = User.Identity.GetUserID();
    IEnumerable<Message> inboxMessages = Context
           .Messages
           .Where(x => Context.Recipients
                              .Where(r => r.RecipientMemberId == userId)
                              .Any(r => x.MessageId == r.MessageId));
