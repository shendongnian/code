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
                "{locale}/Event/{action}/{id}",
                new { controller = "Event", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ProjectName.Areas.Event.Controllers" }
            );
        }
    }
