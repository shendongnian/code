    public static class DockSiteViewModelBehavior
    {
        ... 
    
        public static readonly RoutedEvent OnModelActiveChnagedEvent = EventManager.RegisterRoutedEvent(
          "OnModelActiveChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (DockSiteViewModelBehavior));
    
        public static void AddOnModelActiveChangedHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.AddHandler(OnModelActiveChnagedEvent, handler);
            }
        }
        public static void RemoveOnModelActiveChangedHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (uie != null)
            {
                uie.RemoveHandler(OnModelActiveChnagedEvent, handler);
            }
        }
    
        ...
    
        private static void OnActiveModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DockSite dockSite = d as DockSite;
            if (dockSite == null)
                return;
    
            dockSite.RaiseEvent(new RoutedEventArgs(OnModelActiveChnagedEvent, dockSite));
        }
    }
