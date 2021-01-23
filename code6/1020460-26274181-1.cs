    var group = new Group
    {
        Name = "Group Name",
        ShortName = "GN",
        GroupTypeId = 1,
        ContactDetails = new ContactDetails {
            Address = "Address",
            CompanyName = "Company",
            FirstName = "First",
            LastName = "Last",
            Title = "Title",
        }
    };
    db.Save(group);
    var result = db.SingleById<Group>(group.GroupId);
    result.PrintDump();
