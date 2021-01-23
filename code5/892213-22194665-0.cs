    public class BaseController : Controller
    {
        public void Success(string message)
        {
            TempData.Add("S", message);
        }
    }
