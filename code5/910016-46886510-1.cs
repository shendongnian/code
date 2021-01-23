     public class HomeController : Controller
    {
        public ActionResult Index()
        {
             string[] allimage = System.IO.Directory.GetFiles(Server.MapPath("~/Content/Images/"));
            if (allimage.Length>0)
            {
                List<string> base64text = new List<string>();
                foreach (var item in allimage)
                {
                    base64text.Add(System.IO.File.ReadAllText(item.ToString()));
                }
                ViewBag.Images = base64text;
            }
           
            return View();
        }
      
      
        [HttpPost]
        public void SaveImage(string base64image)
        {
          System.IO.File.WriteAllText(Server.MapPath("~/Content/Images/" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".txt"), base64image);
        }
    }
