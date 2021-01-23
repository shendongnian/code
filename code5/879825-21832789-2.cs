    public static class UIElementExtensions
    {
        public static void HandleAllPreviewMouse(this UIElement uiElement, RoutedEventHandler handler)
        {
            var elementType = uiElement.GetType();
    
            foreach (var eventInfo in elementType.GetEvents().Where(ei => ei.Name.Contains("PreviewMouse")))
            {
                var specificHandler = Delegate.CreateDelegate(eventInfo.EventHandlerType, handler.Method);
                eventInfo.AddEventHandler(uiElement, specificHandler);
            }
        }
    }
