    public static void RegisterBundles(BundleCollection bundles)
    {
     bundles.Add(new ScriptBundle("Root/Assets/js").Include(
                 "Root/Assets/Js/*.js")); //You put your path where there is the Root
     bundles.Add(new StyleBundle("Root/Assets/css").Include(
                 "Root/Assets/CSS/*.css")); //You put your path where there is the Root
     
     
         // Code removed for clarity.
    }
