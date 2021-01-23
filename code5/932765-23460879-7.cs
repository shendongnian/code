    public class ApiController ThemeController
    {
        private ThemeService _themeService;
         
        public ThemeController(ThemeService service) // along with any other needed services
        {
            _themeService = service;
        }
        public IEnumerable<VotingModel> Get(int page = 1, int size = 10)
        {
            //get all themes
            List<Theme> themes = _themeService.GetAll(page, size);
            //convert themes to VotingModel (same model as Theme just without converting system throw an error about serializing object and also add new filed UserName).
            List<VotingModel> model = themes.Select(t =>
                {
                    MembershipUser membershipUser = Membership.GetUser(t.UserId ?? -1);
                    return t.ToVotingModel(membershipUser != null ? membershipUser.UserName : string.Empty);
                }).ToList();
            return model;
    }
