    using System.Web.Http;
    using Breeze.ContextProvider.EF6;
    using Breeze.WebApi2;
    
    namespace MvcApplication1.Controllers
    {
        [BreezeController]
        public class BreezeController : ApiController
        {
            readonly EFContextProvider<DataContext> _contextProvider = 
                new EFContextProvider<DataContext>();
    
            [HttpGet]
            public string Metadata()
            {
                return _contextProvider.Metadata();
            }
        }
    }
