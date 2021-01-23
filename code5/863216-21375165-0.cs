    new UserGridModel()        
    {
        ID = x.ID,
        Username = x.Username,
        EMail = x.ContactInformation.EMail,
        Surname = x.ContactInformation.Surname,
        Role = x.Role1.Description
    }
