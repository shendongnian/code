    public class ProfileService : Service
    {
        public object Get(Profiles request)
        {
            var testProfile = new Profile { Id= "123", GivenName = "Bob", SurName = "Smith", Gender = "Male", FavColor = "Red", 
                    SocialNetworks = new List<BaseResponse>
                        {
                            new SocialNetwork { Id = "abcde", SiteName = "Facebook", ProfileUrl = "http://www.facebook.com/"}
                        }
            };
            if (!String.IsNullOrEmpty(this.Request.QueryString.Get("fields")) || !String.IsNullOrEmpty(this.Request.QueryString.Get("expand")))
                return ServiceHelper.BuildResponseObject<Profile>(testProfile, this.Request.QueryString);
            return testProfile;
        }
    }
    public class SocialNetworkService : Service
    {
        public object Get(SocialNetworks request)
        {
            var testSocialNetwork = new SocialNetwork
                {
                    Id = "abcde",
                    SiteName = "Facebook",
                    ProfileUrl = "http://www.facebook.com/"
                };
            if (!String.IsNullOrEmpty(this.Request.QueryString.Get("fields")) || !String.IsNullOrEmpty(this.Request.QueryString.Get("expand")))
                return ServiceHelper.BuildResponseObject<SocialNetwork>(testSocialNetwork, this.Request.QueryString);
            return testSocialNetwork;
        }
    }
