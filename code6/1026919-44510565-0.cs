    using System.Web.Mvc;//add this to make sure you are referencing the MVC version
    public class FilterConfig
    {
        public static void Configure(System.Web.Mvc.GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute { View = "Error" });
        }
    }
