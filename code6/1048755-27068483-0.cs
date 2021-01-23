    	var contactList = new List<ContactModel> { new ContactModel {CustomKey = "1", ContactGroups = new[]{"Group A"} },
    												new ContactModel {CustomKey ="2", ContactGroups = new[]{"Group A", "Group B", "Group C"} },
    												new ContactModel {CustomKey ="3",ContactGroups = new[] {"Group C", "Group D"} },
    												new ContactModel {CustomKey ="4", ContactGroups = new[]{"Group A", "Group B", "Group C", "Group D"}},
    												new ContactModel {CustomKey ="5", ContactGroups = new[]{"Group A", "Group C", "Group D"}},
    												new ContactModel {CustomKey ="6", ContactGroups = new[]{ "Group D"}},
    												new ContactModel {CustomKey ="7", ContactGroups = new[]{"Group C"}},};
    
        var CheckFor = new List<string>{"Group A", "Group B"};
    	
    	var selectedContracts =
        from contact in contactList
        where contact.ContactGroups.Any(x => CheckFor.Contains(x))
        select new { contact.CustomKey, contact.ContactGroups };
