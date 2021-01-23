    return GenRepo.Context.Member.Where(m => m.MemberID == MemberID)
        .Select(m => new {
            MemberID = m.MemberID,
            FirstName = m.FirstName,
            LastName = m.LastName,
            Email = m.Email,
            MemberAddresses = m.Where(ma => ma.IsDeleted == false)
        });
