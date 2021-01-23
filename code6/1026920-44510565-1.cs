    using System.Web.Mvc;//add this to make sure you are referencing the MVC version
    public class FilterConfig
    {
        public static void Configure(System.Web.Mvc.GlobalFilterCollection filters)
        {
            // Note I added {View = "Error"}. This applies the Error View Page to all Actions in all Controller classes
            filters.Add(new HandleErrorAttribute { View = "Error" });
        }
    }
