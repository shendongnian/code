    public void MergeAllDictionaries(ResourceDictionary appDictionary) {
    	// First copy all keys from MainApp to a new Dictionary
    	ResourceDictionary mainDictionary = new ResourceDictionary();
    	foreach(var keys in appDictionary.MergedDictionaries) {
    		foreach(var keys1 in keys) {
    			mainDictionary.Add(keys1.Key, keys1.Value);
    		}
    	}
    
    	// Then clear all
    	appDictionary.Clear();
    
    	// Get the ClassLibrary dictionary
    	ResourceDictionary classLibraryDictionary = new ResourceDictionary();
    	classLibraryDictionary.Source = new Uri("ms-appx://Common/yourclasslibraryname/ClassLibraryDictionary.xaml", UriKind.RelativeOrAbsolute);
    
    	// First add the ClassLibrary keys and values
    	appDictionary.MergedDictionaries.Add(classLibraryDictionary);
    	// Then add the old values, so that they overwrite the ClassLibrary ones
    	appDictionary.MergedDictionaries.Add(mainDictionary);
    }
