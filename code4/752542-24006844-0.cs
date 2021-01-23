    var test = new int[][] { new int[] {1,2,3}, new int[] {4,5,6} };
    			
    var settings = new PrettyPrintMinimod.Settings();
    settings.PreferMultiline(true);
    Debug.WriteLine(test.PrettyPrint(settings));
    
