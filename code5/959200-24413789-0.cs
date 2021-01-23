    public partial class RouteProvider : IRouteProvider
        {
            public void RegisterRoutes(RouteCollection routes)
            {
                routes.MapRoute("Nop.Plugin.Category.ShopByCategory.Views.Category.List",
                     "Category/List",
                    new { controller = "Category", action = "List" },
                    new[] { "Nop.Plugin.Category.ShopByCategory.Controllers" });
            }
            public int Priority
            {
                get { return 0; }
            }
        }
