    var test = "";
    foreach (MembersForumProperties t in loopThroughDateTimes)
    {
        test = t.ForumMemberDateTimePostedPost;
    }
    // test now contains the date/time of the last item in the `loopThroughDateTimes` list
    var membersMostRecentPost = new MostRecentPostsViewModel
    {
        SelectMostRecentForumPosts = displyMostRecentForumPosts,
        DateAndTimeOfForumPosts = IsPostLessThanOneHour.DisplayPostInMinutesOrSeconds(test)
    };
    // DateAndTimeOfForumPosts only contains the relative string for the last date/time
