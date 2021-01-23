    public IQueryable<PersonDashboardDTO> GetPeopleByRangeForDashboard(int start, int length)
    {
        return databaseContext.Profile
            .IsNotDeleted()
            .OrderedByLastName()
            .TakeRange(start, length)
            .MapToPersonDashboardDTO();
    }
