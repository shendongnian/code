    namespace Jukebox.Controllers
    {
        public class Home : NancyModule
        {
            public Home()
            {
                Get["/"] = x =>
                {
                    return Response.AsFile("default.htm");
                };
            }    
        }
    }
