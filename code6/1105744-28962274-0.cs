     string testName = @"Emailcampaign\example_at_gmail_dot_com";
                //Request["ec_recipient"]
                var currentUser = Sitecore.Security.Accounts.User.FromName(testName, true);
    
                var interests = new List<ID>();
                using (new SecurityEnabler())
                {
                    using (new Sitecore.Security.Accounts.UserSwitcher(currentUser))
                    {
                        var w = currentUser.Profile.GetCustomProperty("Sectors");
    
                        var currentUserCustomProfile = currentUser.Profile as UserProfile;
                        currentUserCustomProfile.Initialize(testName, true);
                        currentUserCustomProfile.Reload();
    
                        interests.AddRange(currentUserCustomProfile.Interests);
                    }
                }
