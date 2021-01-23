    private IEnumerable<User> GetUsersWithNotices( DateTime minDate, DateTime maxDate, etc... )
    {
        return UserRepository.FindAll( u => u.Active && !u.Whatever
                                            && u.JoinDate > minDate && u.JoinDate < maxDate
                                            && u.Notices.Any( n => n.Active && !n.Something
                                                                   && Whatever
                                                                   && etc... ) );
    }
