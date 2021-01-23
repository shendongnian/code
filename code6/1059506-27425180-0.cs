    var userDict = user.Partners.SelectMany(
        p =>
            p.Programmes.SelectMany(
                prg =>
                prg.TeamMembers.Select(
                    t => new { PartnerId = p.Id, TeamMemb = t.ApplicationUserId })))
             .GroupBy(r => r.TeamMemb)
             .ToDictionary(g => g.Key, g => g.Select(i => i.PartnerId).ToList());
