    var query = 
        user.Partners
            .SelectMany(x=>x.Programmer)
            .SelectMany(x=>x.TeamMembers)
            .Select(x=> new { partner = partner.Id, applicationUser = tm.ApplicationUser })
            .GroupBy(x=>x.applicationUser)
            .Select(x=>new { x.applicationUser, partners = x.Select(y=>y.partner) }) ;
