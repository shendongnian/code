        [Authorize(Role="AppleAdmin")]
        [Route("BasicController")]
        public class BasicControllerApple : Controller
        {
            public ActionResult Apple1() 
            {
            }
        }
        [Authorize(Role="MangoAdmin")]
        [Route("BasicController")]
        public partial class BasicControllerMango : Controller
        {
            public ActionResult Mango1() 
            {
            }
        }
