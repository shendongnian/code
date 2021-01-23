       class Program
       {
          static void Main(string[] args)
          {
             IconManager.FindIconsInResources(Resources1.ResourceManager);
             //IconManager.FindIconsInResources(Resources2.ResourceManager);
             //IconManager.FindIconsInResources(Resources3.ResourceManager);
    
             Image iconImage = IconManager.GetIcon("Incors_office_building_16x16");
          }
       }
    
    
       public static class IconManager
       {
          private static readonly Dictionary<string, ResourceSet> _iconDictionary = 
                                                                 new Dictionary<string, ResourceSet>();
          
          /// <summary>
          /// Method to read the resources info for an assembly and find all of the icons and add them 
          /// to the icon collection.
          /// </summary>
          public static void FindIconsInResources(ResourceManager resourceManager)
          {
             // Get access to the resources (culture shouldn't matter, but has to be specified)
             ResourceSet resourceSet = 
                       resourceManager.GetResourceSet(CultureInfo.GetCultureInfo("en-us"), true, true);
             if (resourceSet == null)
                throw new Exception("Unable to create ResourceSet.");
    
             // Top of loop to examine each resource object 
             foreach (DictionaryEntry dictionaryEntry in resourceSet)
             {
                // Check it's an icon (or some kind of graphic)
                if (!(dictionaryEntry.Value is Bitmap))
                   continue;
    
                // Get the resource name, which is basically the filename without ".png" and with '-' 
                //  and blanks converted to '_'. Ignore .ico files.
                string resourceKey = (string)dictionaryEntry.Key;
                if (resourceKey.EndsWith("_ico", StringComparison.Ordinal))
                   continue;
    
                // Add (or replace) the icon in the icon dictionary
                _iconDictionary[resourceKey] = resourceSet;
             }
          }
    
    
          /// <summary>
          /// Method to get an icon image from one of several resource files.
          /// </summary>
          public static Image GetIcon(string iconName)
          {
             ResourceSet resourceSet;
             _iconDictionary.TryGetValue(iconName, out resourceSet);
             if (resourceSet == null)
                return null;
             
             return (Image)resourceSet.GetObject(iconName);
          }
       }
