    using <your project's name>.Models
    public class GeneralHelpers
    {
        public static string GetUserId()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var user = db.Users.FirstOrDefault(u => u.UserName == HttpContext.Current.User.Identity.Name);
            return user.Id;
        }
    }
