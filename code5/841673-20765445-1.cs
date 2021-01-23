    public class UserRating
    {
       public string UserIP = null;
       public IDictionary<int, int> Ratings = null;
    }
    
    private void OnSubmitRatingHandler(...)
    {
    ... other stuff...
    string clientIp = (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
    UserRating UserRating = new UserRating();
    UserRating.UserIP = clientIP;
    UserRating.Ratings = Ratings;
    Session.Add("UserRatings", UserRating);
    }
