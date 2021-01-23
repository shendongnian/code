    Change it to
    public class EventAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Event";
            }
        }
    
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Event_default",
                "Event/{controller }/{action}/{id}",   //change here add controller
                new { controller = "Event", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ProjectName.Areas.Event.Controllers" }
            );
        }
    }
