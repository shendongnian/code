    public class MyViewEngine : RazorViewEngine
    {
        private static string[] AdditionalViewLocations = new[]{
            "~/Random/{0}.cshtml"
        };
    
        public MyViewEngine()            
        {
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(AdditionalViewLocations).ToArray();
            base.ViewLocationFormats = base.ViewLocationFormats.Union(AdditionalViewLocations).ToArray();
            base.MasterLocationFormats = base.MasterLocationFormats.Union(AdditionalViewLocations).ToArray();
        }
    }
