public class ContactsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Contacts";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Contacts_default",
                "Contacts/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MvcApplication1.Areas.Contacts.Controllers" }
            );
        }
    }
