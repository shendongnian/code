    private static bool CompareFilter(UserProfile profile, FilterViewModel filter)
    {
        if (filter.FirstName != null && 
            (profile.FirstName == null ||
             profile.FirstName.CompareTo(filter.FirstName) != 0))
        {
            return false;
        }
 
        if (filter.TownId != null &&
            profile.TownId != filter.TownId
        {
            return false;
        }
        // true if at least one of the filter interests match
        if (filter.InterestsIds != null)
        {
            var foundMatch = profile.Interests
                 .Any(i => filter.InterestsIds.Contains(i.Id));
            if (!foundMatch)
            {
                return false;
            }
        }
        ...
        return true;
    }
