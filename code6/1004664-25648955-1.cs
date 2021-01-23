    public class HomeController : Controller {
        public string Index(string id) {
            return "Index " + id;
        }
        public string _(string id) {
            return id;
        }
    }
