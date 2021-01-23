    public class ResourceResolutionManager
    {
        public static DependencyProperty ResolutionProperty =
                DependencyProperty.RegisterAttached("Resolution", typeof(Resolutions?), typeof(ResourceResolutionManager),
                        new PropertyMetadata(null, ResolutionChanged));
    
        private static void ResolutionChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && (Resolutions)e.NewValue != ScreenExtension.CurrentResolution)
            {
                var dict = obj as ResourceDictionary;
    
                if (dict != null)
                {
                    dict.Clear();
                }
            }
        }
    
        public static void SetResolution(DependencyObject obj, Resolutions? resolution)
        {
            obj.SetValue(ResolutionProperty, resolution);
        }
    
        public static Resolutions? GetResolution(DependencyObject obj)
        {
            return (Resolutions?)obj.GetValue(ResolutionProperty);
        }
    }
