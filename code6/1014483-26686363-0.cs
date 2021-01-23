    public class FacebookDeauthModel
    {
        public string signed_request { get; set; }
    }
    [AllowAnonymous]
    [Route("FacebookDeauthorize")]
    [HttpPost]
    public async Task<IHttpActionResult> FacebookDeauthorize(FacebookDeauthModel model)
    {
        FacebookClient fb = new FacebookClient();
        dynamic signedRequest = JsonConvert.DeserializeObject(fb.ParseSignedRequest("YOUR_APP_SECRET", model.signed_request).ToString());
        string FBUserID = signedRequest.user_id;
        ApplicationUser user = UserManager.FindBy(x => x.FBAppID == FBUserID);
        if (user != null)
        {
            user.IsActive = false;
            user.InactiveReason = "Facebook deauthorized on " + DateTime.UtcNow;
            await UserManager.UpdateAsync(user);
        }
        else
        {
            _tracer.Error(Request, "FacebookDeauthorize", "Facebook tried to deauthorize a user we do not have record of, FBAppID: {0}", FBUserID);
        }
        return Ok();
    }
