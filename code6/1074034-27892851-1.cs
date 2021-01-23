        using System.Web.Hosting;
    
         namespace MyApp.Notifications
         {
             public class CustomEmails
             {
                 public static string GetWebsiteRoot()
                 {
                     // Get the website root
                     return HostingEnvironment.MapPath("~/");
                 }
             }
         }
