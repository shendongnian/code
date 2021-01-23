    using System;
    using Windows.ApplicationModel.Resources;
    
    namespace MyClassLibraryName.Tools {
    	public static class LocalizationTool {
    		static ResourceLoader resourceLoader = null;
    
    		public static string MyStringOne {
    			get {
    				String name;
    				GetLibraryName("MyStringOne", out name);
    				return name;
    			}
    		}
    
    		private static void GetLibraryName(string resourceName, out string resourceValue) {
    			if(resourceLoader == null) {
    				resourceLoader = ResourceLoader.GetForCurrentView("MyClassLibraryName/Resources");
    			}
    			resourceValue = resourceLoader.GetString(resourceName);
    		}
    	}
    }
