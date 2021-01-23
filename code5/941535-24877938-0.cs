    public class Region : Behavior<ContentControl>
    {
        public static readonly DependencyProperty DefaultViewTypeProperty = DependencyProperty.Register(
            "DefaultViewType", 
            typeof(Type),
            typeof(Region), 
            new PropertyMetadata(default(UserControl)));
        public Type DefaultViewType
        {
            get { return (Type)GetValue(DefaultViewTypeProperty); }
            set { SetValue(DefaultViewTypeProperty, value); }
        }
        public static readonly DependencyProperty RegionNameProperty = DependencyProperty.RegisterAttached(
            "RegionName",
            typeof(string),
            typeof(Region),
            new PropertyMetadata(default(string)));
        public string RegionName
        {
            get { return (string)GetValue(RegionNameProperty); }
            set { SetValue(RegionNameProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            ShowDefaultView();
            RegisterRegionWithManager();
        }
        private void ShowDefaultView()
        {
            if (DefaultViewType == null)
                return;
            if (DesignerProperties.GetIsInDesignMode(AssociatedObject))
            {
                var constructorInfo = DefaultViewType.GetConstructors().First();
                var parameters = new List<object>();
                constructorInfo.GetParameters().ToList().ForEach(p => parameters.Add(null));
                AssociatedObject.Content = constructorInfo.Invoke(parameters.ToArray());
            }
            else
            {
                var serviceLocator = ServiceLocator.Current;
                AssociatedObject.Content = serviceLocator.GetInstance(DefaultViewType);    
            }
        }
        private void RegisterRegionWithManager()
        {
            if (DesignerProperties.GetIsInDesignMode(AssociatedObject))
                return;
            
            var serviceLocator = ServiceLocator.Current;
            var navigationService = serviceLocator.GetInstance<IRegionManager>();
            if (navigationService != null)
                navigationService.RegisterRegion(RegionName, AssociatedObject);
        }
    }
