    REACTION reaction = new REACTION
    {
        content = "blablabla",
        date = DateTime.Now
    };
    // At this point reaction.ID == 0 or null
    db.REACTIONs.InsertOnSubmit(reaction);
    db.SubmitChanges();
    var id = reaction.ID; // Now ID will have the value that was generated when the row was inserted
