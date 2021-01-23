    public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
            "Xahoi_default",
            "Xahoi/{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new[] { "Nop.Web.Areas.Xahoi.Controllers" });
        }
