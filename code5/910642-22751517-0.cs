    User user = ...
    var contactIds = user.Contacts.Select(c => c.Id).ToArray();
    var usersWithMatchingContacts = this.unitOfWork.UserRepository.Get()
        // basically, we're checking that the number of matching contacts is the same as the
        // total number of contacts for the user, which means that the user has the same
        // set of contacts. If you just want to require some overlap, change 
        // the "== u.Contacts.Count" to "> 0"
        .Where(u => u.Contacts.Count(c => contactIds.Contains(c.Id)) == u.Contacts.Count);
