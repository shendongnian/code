    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    
    namespace WebApplication1.Controllers
    {
        public class ApiMethodController : ApiController
        {
            public IEnumerable<HelpMethod> GetMethods()
            {
                // get the IApiExplorer registered automatically
                IApiExplorer ex = this.Configuration.Services.GetApiExplorer();
    
                // loop, convert and return all descriptions 
                return ex.ApiDescriptions
                    // ignore self
                    .Where(d => d.ActionDescriptor.ControllerDescriptor.ControllerName != "ApiMethod")
                    .Select(d =>
                    {
                        // convert to a serializable structure
                        return new HelpMethod
                        {
                            Parameters = d.ParameterDescriptions.Select(p => new HelpParameter
                            {
                                Name = p.Name,
                                Type = p.ParameterDescriptor.ParameterType.FullName,
                                IsOptional = p.ParameterDescriptor.IsOptional
                            }).ToArray(),
                            Method = d.HttpMethod.ToString(),
                            RelativePath = d.RelativePath,
                            ReturnType = d.ResponseDescription.DeclaredType == null ?
                                null : d.ResponseDescription.DeclaredType.ToString()
                        };
                    });
            }
        }
        public class HelpMethod
        {
            public string Method { get; set; }
            public string RelativePath { get; set; }
            public string ReturnType { get; set; }
            public IEnumerable<HelpParameter> Parameters { get; set; }
        }
        public class HelpParameter
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public bool IsOptional { get; set; }
        }
    }
