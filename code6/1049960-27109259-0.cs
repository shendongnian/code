        [SessionState(System.Web.SessionState.SessionStateBehavior.Disabled)]
        public class ImageController : Controller
        {
          public ActionResult GetThumbnail(string code)
          {
              byte[] image = _dataProvider.GetThumbnailImage(code);
              return this.Image(image, "image/jpeg");
          }
        }
