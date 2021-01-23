        namespace PlayVideoInMVC.Controllers
        {
            public class VideoDataController : Controller
            {
                //
                // GET: /VideoData/
                public ActionResult Index()
                {
                    return new VideoDataResult();
                }
            }
        }
