    private static bool CompareFilter(UserProfile profile, FilterViewModel filter)
    {
        if (filter.FirstName != null && filter.FirstName != profile.FirstName)
        {
            return false;
        }
 
        if (filter.TownId != null && filter.TownId != profile.TownId)
        {
            return false;
        }
        // true if at least one of the filter interests match
        if (filter.InterestsIds != null &&
            !profile.Interests.Any(i => filter.InterestsIds.Contains(i.Id)))
        {
            return false;
        }
        ...
        return true;
    }
