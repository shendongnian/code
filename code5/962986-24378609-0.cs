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
    
            private void PageTitle_Tap(object sender, System.Windows.Input.GestureEventArgs e)
            {
                ApplicationTitle.Style = (Style)ApplicationTitle.TryFindResource("PhoneTextTitle1Style");
            }
