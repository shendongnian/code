    public class MyWhey
    {
        public static List<ef_GetMyWhey_Result> GetMyWhey()
        {
            currentUserID = User.Identity.GetUserId(); 
            return _db.ef_GetMyWhey(currentUserID).ToList();
        }
    }
