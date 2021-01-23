    public class ListController : BaseApiController
    {
        //main is "global"
        public dynamic Get(string id)//JObject values)
        {
            //I can test here for anonymous as well, even if I allow anonymous
    
            //Example using my own convention on User Profile Class populated by ScrubbedUser constructor
            if (CurrentUser.Profile.CustId == "public")
            {
                return HttpStatusCode.Forbidden;
            }
            //Redundant Code
            if (!User.Identity.IsAuthenticated)
            {
                return HttpStatusCode.Forbidden;
            }
            string filterExt = string.IsNullOrEmpty(id) || id=="global"
                ? "*" : id;
            return ListRepository.GetList(filterExt, SSUser);
        }
        [Authorize]
        public dynamic Post(JObject values)
        {
            //Just a sample, this will not fire unless the user is authenticated
            return CurrentUser.JSONRecord;
        }
    }
