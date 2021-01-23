    public static class DateTimeExt
    {
        public static string ToRelativeTime(this DateTime value)
        {
            // you could move the entire implementation of `DisplayPostInMinutesOrSeconds` to here
            return IsPostLessThanOneHour.DisplayPostInMinutesOrSeconds(value);
        }
    }
    ...
    
    public PartialViewResult MostRecentMembersPosts()
    {
        return PartialView("pvMostRecentMembersPost", _imf.DisplayMostRecentForumPosts().ToList());
    }
