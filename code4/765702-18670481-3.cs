    public static class FrameworkElementExtensions
    {
        public static object TryFindResource(this FrameworkElement element, object resourceKey)
        {
            var currentElement = element;
 
            while (currentElement != null)
            {
                var resource = currentElement.Resources[resourceKey];
                if (resource != null)
                {
                    return resource;
                }
 
                currentElement = currentElement.Parent as FrameworkElement;
            }
 
            return Application.Current.Resources[resourceKey];
        }
    }
    /**********************************************************************/
    // Or, the recursive version of TryFindResource method as suggested by @Default:
    
    public static object TryFindResource(this FrameworkElement element, object resourceKey)
    {
        if (element == null)
            return Application.Current.Resources[resourceKey];
    
        var resource = element.Resources[resourceKey];
        if (resource != null)
        {
            return resource;
        }
        return TryFindResource(element.Parent, resourceKey);
    }
