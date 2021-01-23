    public class SiteManagerModelBinder : IModelBinder
        {
            #region IModelBinder Members
    
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                if (bindingContext.Model != null)
                {
                    throw new InvalidOperationException("Cannot update instances");
                }
                
                // Apply your condition to determine if site number is in Url.
                if (controllerContext.RouteData.Values['siteNum']!=null)
                {
                   // probably want to resolve this from container just hard coding as example, assumption is that SiteManager, does the repository bits for you.
                   return new SiteManager((int)controllerContext.RouteData.Values['siteNum']);
                }
                return null;
            }
    
            #endregion
        }
