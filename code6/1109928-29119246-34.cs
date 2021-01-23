    protected override Window EnsureWindow(object rootModel, object view, bool isDialog)
    {
        var window = view as ModernWindow;
        if (window == null)
        {
            window = new ModernWindow();
            // Get the namespace of the view control
            var t = view.GetType();
            
            var ns = t.Namespace;
            // Subtract the project namespace from the start of the full namespace
            ns = ns.Remove(0, 12);
        
            // Replace the dots with slashes and add the view name and .xaml
            ns = ns.Replace(".", "/") + "/" + t.Name + ".xaml";
            // Set the content source to the Uri you've made
            window.ContentSource = new Uri(ns, UriKind.Relative);
            window.SetValue(View.IsGeneratedProperty, true);
        }
        return window;
    }
