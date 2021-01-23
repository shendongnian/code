    namespace ICSWebPortal.Portal.Controls.Users
    {
        public partial class CreateUser : ICSBaseUserControl
        {
            UserRepository userDao = new UserRepository();
            User user = new User();
            DateTime date = Convert.ToDateTime("2012-09-14 00:00:00.000");
        } // these should be after your methods
    }     //
