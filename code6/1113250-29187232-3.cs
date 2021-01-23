    public class MyWhey
    {
        public static List<ef_GetMyWhey_Result> GetMyWhey()
        {
            string currentID = HttpContext.Current.GetOwinContext().Authentication.User.Identity.GetUserId();
            return _db.ef_GetMyWhey(currentUserID).ToList();
        }
    }
