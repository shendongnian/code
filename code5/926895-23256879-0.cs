    public static void RegisterBundles(BundleCollection bundles)
    {
     bundles.Add(new ScriptBundle("~/Assets/js").IncludeDirectory(
                 "Root/Assets/Js/*.js")); //You put your path where there is the Root
     bundles.Add(new StyleBundle("~/Assets/css").IncludeDirectory(
                 "Root/Assets/CSS/*.css")); //You put your path where there is the Root
     
     
         // Code removed for clarity.
    }
