    var set = WindowsFormsApplication1.Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true);
    
    // How do I store images from Resources folder to a List or array?
    var resourceList = set.Cast<System.Collections.DictionaryEntry>().Select(item => item.Value);    
    // How am I supposed to get names of all the images in a list or array?
    var nameList = set.Cast<System.Collections.DictionaryEntry>().Select(item => item.Key);    
    // How do I get names of images with a particular prefix like img1, img2.... ?
    var dicResources = set.Cast<System.Collections.DictionaryEntry>().ToDictionary(item => item.Key, item => item.Value);
