    ResourceDictionary resourceDictionary = new ResourceDictionary
    {
    	Source = new Uri("/BaseLib.Services.TabControlServices;component/TabStyles.xaml", UriKind.RelativeOrAbsolute)
    };
    tabItem.Style = resourceDictionary["TabItemStyle"] as Style;
