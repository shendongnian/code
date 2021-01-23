    return (GenRepo.Context.Member.Where(m => m.MemberID == MemberID)
            .Select(m => new {
                MemberID = m.MemberID,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email,
                MemberAddresses = m.MemberAddresses.Where(ma => ma.IsDeleted == false)
            })).ToList()
            .Select( m => new Member {
                MemberID = m.MemberID,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email,
                MemberAddresses = m.MemberAddresses
            }).First();
