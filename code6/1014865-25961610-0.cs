    public class MyModel
    {
        int UserId{ get; set; }
        string DisplayName { get; set; }
        string AvatarPath { get; set; }
        DateTime LastActivityDate { get; set; }
        int Votes { get; set; }
        int Cures { get; set; }
        string LinkTitle { get; set; }
        string LinkURL { get; set; }
        string AboutMe { get; set; }
    }
    ...
    public static List<MyModel> GetUserProfile(Guid guid)
    {
        var UserProfileContext = new DataContext.UserProfileDataContext();
        var UserProfile = (from p in UserProfileContext.aspnet_Profiles
                              join u in (from u in UserProfileContext.aspnet_Users 
                                  where u.UserId == guid select u)
                              on p.UserId equals u.UserId
                              select new MyModel
                              {
                                  UserId = u.UserId,
                                  DisplayName = u.DisplayName,
                                  AvatarPath = u.AvatarPath,
                                  LastActivity = u.LastActivityDate,
                                  Votes = u.Votes,
                                  Cures = u.Cures,
                                  LinkTitle = u.LinkTitle,
                                  LinkURL = u.LinkURL,
                                  AboutMe = p.AboutMe
                              }).ToList();
        return UserProfile;
    }
