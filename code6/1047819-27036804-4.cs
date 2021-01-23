    public  class UserController : Controller
    {
        [OutputCache(Duration = 600, VaryByCustom = "session")]
        public virtual FileContentResult UserImage()
        {
