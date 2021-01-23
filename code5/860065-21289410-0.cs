    using System.Net.Http;
    using System.Web;
    using Sitecore.Mvc.Extensions;
    using Sitecore.Mvc.Pipelines.Response.RenderRendering;
    using Sitecore.Mvc.Presentation;
    namespace My.Site.Pipelines
    {
        public class GenerateCustomCacheKey : GenerateCacheKey
        {
            protected override string GenerateKey(Rendering rendering, RenderRenderingArgs args)
            {
                var varyByCountryCode = rendering.RenderingItem.InnerItem["VaryByMyCustomThing"].ToBool();
    
                var key = base.GenerateKey(rendering, args);
                if (varyByCountryCode)
                    key = key + GetCountryCodePart(rendering);
                return key;
            }    
            protected string GetCountryCodePart(Rendering rendering)
            {
                return "_#countryCode:" + (string)HttpContext.Current.Session["CountryCode"];
            }
        }
    }
