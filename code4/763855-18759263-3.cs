    [ProfilingActionFilter]
    public class BaseController : ServiceStackController<CustomUserSession>
    {
        /// <summary>
        /// Surcharge de l'action pour charger la notification dans le ViewBag s'il y en a une et l'a marquer comme delivrée
        /// </summary>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            int Id = 0;
            UserViewModel user= new UserViewModel ();
            if (int.TryParse(base.UserSession.UserAuthId, out Id))
            {
                user= new UserViewModel ()
                {
                    id = Convert.ToInt32(base.UserSession.UserAuthId),
                    nom = base.UserSession.DisplayName,
                    roles = base.UserSession.Roles != null ? string.Join(",", base.UserSession.Roles.ToArray()) : string.Empty
                };
            }
            ViewBag.User= user;
        }
