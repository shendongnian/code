    from cli in Clients
    where cli.ClientID == 6
    join er in EntityRelationships on cli.EGUID equals er.ParentID
    join con in Contacts on er.ChildID equals con.EGUID
    select new
    {
        ContactID = con.ContactID,
        ContactLastName = con.ContactLastName,
        ContactFirstName = con.ContactFirstName,
        ContactTitle = con.ContactTitle,
        Emails = 
            from erEmail in EntityRelationships
            where er.EGUID == erEmail.ParentID
            join ea in EmailAddresses on r.ChildID equals ea.EGUID
            where EntityDefaultValues.Any(eaDefault => r.ID == eaDefault.RelationshipID
            select ea
    }
