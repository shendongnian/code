    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : ControllerBaseNoAuthorize
    {
        public JsonResult IsNameAlreadyInUse([Bind(Prefix = "User.Name")]string Name)
        {
            return NameAlreadyInUse(Name);
        }
        protected JsonResult NameAlreadyInUse(string name)
        {
            vvar user = db.User.FirstOrDefault(u => u.UserName == UserName);
            if (user == null)
                return Json(true, JsonRequestBehavior.AllowGet);
        }
        }
