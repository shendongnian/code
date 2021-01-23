    public class Profile : BaseResponse
    {
        protected override string hrefPath { get { return "https://host/profiles/"; } }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public string Gender { get; set; }
        public string FavColor { get; set; }
        public List<BaseResponse> SocialNetworks { get; set; }
    }
    public class SocialNetwork: BaseResponse
    {
        protected override string hrefPath { get { return "https://host/socialNetworkMemberships?profileId="; }}
        public string SiteName { get; set; }
        public string ProfileUrl { get; set; }
    }
