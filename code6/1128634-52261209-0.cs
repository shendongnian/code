    public class ShowInSwaggerFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var contextApiDescription in context.ApiDescriptions)
            {
                var actionDescriptor = (ControllerActionDescriptor) contextApiDescription.ActionDescriptor;
                
                if (actionDescriptor.ControllerTypeInfo.GetCustomAttributes<ShowInSwaggerAttribute>().Any() ||
                    actionDescriptor.MethodInfo.GetCustomAttributes<ShowInSwaggerAttribute>().Any())
                {
                    continue;
                }
                else
                {
                    var key = "/" + contextApiDescription.RelativePath.TrimEnd('/');
                    var pathItem = swaggerDoc.Paths[key];
                    if(pathItem == null)
                        continue;
                    switch (contextApiDescription.HttpMethod.ToUpper())
                    {
                        case "GET":
                            pathItem.Get = null;
                            break;
                        case "POST":
                            pathItem.Post = null;
                            break;
                        case "PUT":
                            pathItem.Put = null;
                            break;
                        case "DELETE":
                            pathItem.Delete = null;
                            break;
                    }
                    if (pathItem.Get == null  // ignore other methods
                        && pathItem.Post == null 
                        && pathItem.Put == null 
                        && pathItem.Delete == null)
                        swaggerDoc.Paths.Remove(key);
                }
            }
        }
    }
