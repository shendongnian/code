        private void CreateTab(Type activityType, string tag, string colorcode, int viewId)
    {
        TabHost.TabSpec spec;
        var intent = new Intent(this, activityType);
        intent.AddFlags(ActivityFlags.NewTask);
        spec = TabHost.NewTabSpec(tag);
        View tab = LayoutInflater.Inflate (viewId, null); // viewId = Resource.Layout.TabStyle
        spec.SetIndicator (tab);
        spec.SetContent(intent);
        TabHost.AddTab(spec);
    } 
