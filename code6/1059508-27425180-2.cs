    var userDict = user.Partners.SelectMany(
        p =>
            p.Programmes.SelectMany(
                prg =>
                prg.TeamMembers.Select(
                    t => new { PartnerId = p.Id, TeamMembId = t.ApplicationUserId })))
             .GroupBy(r => r.TeamMembId)
             .ToDictionary(g => g.Key, g => g.Select(i => i.PartnerId).ToList());
