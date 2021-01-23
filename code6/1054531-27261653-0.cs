    public BaseController : Controller
    {
        protected Student GetCurrentStudentInfo() //protected so we can access this method from derived classes
        {
            var currentuser = (SessionModel)Session["LoggedInUser"];
            var student = _db.Student.Find(currentuser.UserID);
    
            return student;
        }
    }
