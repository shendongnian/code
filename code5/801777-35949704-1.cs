        public class InterfaceFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
                ObjectContent content = actionExecutedContext.Response.Content as ObjectContent;
                if (content != null)
                {
                    Type returnType = actionExecutedContext.ActionContext.ActionDescriptor.ReturnType;
                    if (returnType.IsInterface && content.Formatter is JsonMediaTypeFormatter)
                    {
                        var formatter = new JsonMediaTypeFormatter
                            {
                                SerializerSettings =
                                    {
                                        ContractResolver = new InterfaceContractResolver(returnType)
                                    }
                            };
                        actionExecutedContext.Response.Content = new ObjectContent(content.ObjectType, content.Value, formatter);
                    }
                }
            }
        }
