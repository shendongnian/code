    public static readonly DependencyProperty MapCenterProperty =
            DependencyProperty.RegisterAttached("MapCenter", typeof (Location), typeof (MyAttached), 
            new PropertyMetadata(default(Location),MapCenterChanged));
        private static void MapCenterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Map map = d as Map;
            Location location = e.NewValue as Location;
            if (map != null &&location!=null)
            {
                map.Center = location;
            }
        }
        
        public static void SetMapCenter(UIElement element, Location value)
        {
            element.SetValue(MapCenterProperty, value);
        }
        public static Location GetMapCenter(UIElement element)
        {
            return (Location) element.GetValue(MapCenterProperty);
        }
