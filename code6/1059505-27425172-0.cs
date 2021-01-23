    var dict = new Dictionary<string, List<int>>();
    List<ApplicationUser> allUsers = new List<ApplicationUser>();
    var groupedByApplicationUserId = from partner in user.Partners
                                     from programme in partner.Programs
                                     from tm in programme.TeamMembers
                                     select new { ApplicationUserId = tm.ApplicationUserId,
                                                  PartnerId = partner.Id,
                                                  ApplicationUser = tm.ApplicationUser,
                                                 };
    groupedByApplicationUserId.GroupBy(item => item.ApplicationUserId).ToList().ForEach(group =>
    {
        dict.Add(group.Key, group.Select(item => item.PartnerId).ToList());
        allUsers.AddRange(group.Select(item => item.ApplicationUser));
    });
