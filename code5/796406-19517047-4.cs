    public class MostRecentPostViewModel
    {
        public MemberForumProperties Properties { get; set; }
        public string RelativeTime { get; set; }
    }
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
        var viewModels = _imf.DisplayMostRecentForumPosts().Select(x => new MostRecentPostViewModel {
                                                                Properties = x,
                                                                RelativeTime = x.ForumMemberDateTimePostedPost.ToRelativeTime()
                                                            });
        return PartialView("pvMostRecentMembersPost", viewModels.ToList());
    }
