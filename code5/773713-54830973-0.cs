    // This:
    var newEmail = new NewEmailTemplate { Topic = topic };
    // Instead of this:
    var newEmail = new NewEmailTemplate();
    newEmail.Init(topic);
