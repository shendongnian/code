    var allowedRoles = Enum.GetValues(typeof(ApplicationRoles))
        .Cast<ApplicationRoles>()
        .Except(ApplicationRoles.Undefinied); // allow all except undefined
    
    bool isAuthorized = userRoles.Any(r => allowedRoles.Contains(r));
