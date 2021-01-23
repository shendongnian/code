    public class ScrubbedUser
        {
            private IPrincipal Principal { get; set; }
            public ScrubbedUser(string principal)
            {
                Principal = null;
                if (string.IsNullOrEmpty(principal))
                {
                    Profile = GetDefaultProfile();
                }
                else
                {
                    Profile = GetUserProfile(principal);
                }
                //Get User Memberships
                Memberships = GetUserMemberships();
                Settings = GetUserSettings();
            }
            public SurgeStreetUser(IPrincipal principal) 
            {
                Principal = principal;
                if (Principal == null
                    || Principal.Identity == null
                    || Principal.Identity.IsAuthenticated == false
                    || string.IsNullOrEmpty(Principal.Identity.Name))
                {
                    Profile = GetDefaultProfile();
                }
                else
                {
                    Profile = GetUserProfile(Principal.Identity.Name);
                }
                //Get User Memberships
                Memberships = GetUserMemberships();
                Settings = GetUserSettings();
            }
            public UserProfile Profile { get; private set; }
            public List<V_UserMembership> Memberships { get; private set; }
            public List<Setting> Settings { get; private set; }
    
            private UserProfile GetDefaultProfile()
            {
                //Load an Anonymous Profile into the ScrubbedUser instance any way you like
            }
            private UserProfile GetUserProfile(string userName)
            {
                //Load the UserProfile based on userName variable (origin is Principle Identity Name
            }
            private List<V_UserMembership> GetUserMemberships()
            {
                //Load User's Memberships or Roles from Database, Cache or Session
            }
            private UserProfile PopulateCurrentUser(UserProfile userProfile)
            {
                var user = new UserProfile
                {
                    //Convenience Method to clone and set a Profile Property
                };
                return user;
            }
            private List<Setting> GetUserSettings()
            {
                //Get the User's Settings or whatever
            }
            //Convenience to return a JSON string of the User (great to use with something like Backbone.js)
            private dynamic JSONRecord
            {
                get
                {
                    return new
                    {
                        CustId = Profile.CustId,
                        UserName = Profile.UserName,
                        UserId = Profile.UserId,
                        Email = Profile.Email,
                        FirstName = Profile.FirstName,
                        Language = Profile.Language,
                        LastActivityDate = Profile.LastActivityDate,
                        LastName = Profile.LastName,
                        DebugOption = Profile.DebugOption,
                        Device = Profile.Device,
                        Memberships = Memberships,
                        Settings = Settings
                    };
                }
            }
        }
