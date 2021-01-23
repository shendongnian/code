    public class PortalController: Controller {
        public ActionResult News(string city) {
            NewsService newsService = new NewsService();
            ViewStringModel headlines = newsService.GetHeadlines(city);
            return View(headlines);
        }
    } 
