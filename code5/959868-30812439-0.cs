    public class RegionManager
    {
        private static readonly Dictionary<string, Func<object>> RegisteredContent = new Dictionary<string, Func<object>>();
        public static readonly DependencyProperty RegionNameProperty = DependencyProperty.RegisterAttached("RegionName", typeof(string), typeof(RegionManager), new PropertyMetadata(null));
        public static void SetRegionName(DependencyObject target, string name)
        {
            target.SetValue(RegionNameProperty, name);
            if (string.IsNullOrEmpty(name)) return;
            CreateContentRegion(target, name);
        }
        public static string GetRegionName(DependencyObject target)
        {
            return (string)target.GetValue(RegionNameProperty);
        }
        public void RegisterViewWithRegion(string regionName, Func<object> getContentDelegate)
        {
            RegisteredContent.Add(regionName, getContentDelegate);
        }
        private static void CreateContentRegion(DependencyObject target, string name)
        {
            if (target is ContentControl)
            {
                Func<object> value;
                RegisteredContent.TryGetValue(name, out value);
                if (value == null) return;
                ((ContentControl)target).Content = value.DynamicInvoke();
            }
        }
    }
