    public ResourceDictionary Resources
    {
    	get
    	{
    		ResourceDictionary resourceGUIView = new ResourceDictionary();
    		resourceGUIView.Source = new Uri("/GUI;component/Common/ViewResources.xaml", UriKind.RelativeOrAbsolute);
    		ResourceDictionary resourceGUI = new ResourceDictionary();
    		resourceGUI.Source = new Uri("/GUI;component/Common/ResourceDictionary.xaml", UriKind.RelativeOrAbsolute);
    		ResourceDictionary resourceComponent = new ResourceDictionary();
    		resourceComponent.Source = new Uri("/Component;component/Common/ResourceDictionary.xaml", UriKind.RelativeOrAbsolute);
    		
    		ResourceDictionary generalResource = new ResourceDictionary();
    		
    		generalResource.MergedDictionaries.Add(resourceGUIView);
    		generalResource.MergedDictionaries.Add(resourceGUI);
    		generalResource.MergedDictionaries.Add(resourceComponent);
    
    		return generalResource;
    	}
    }
