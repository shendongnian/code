    public static void NotifyOnResourcesChanged(this FrameworkElement element, EventHandler onResourcesChanged)
    {
        ResourcesChangedEvent.AddMethod.Invoke(element, new object[] { onResourcesChanged });
    }
    private static readonly EventInfo ResourcesChangedEvent = typeof(FrameworkElement).GetEvent("ResourcesChanged", BindingFlags.Instance | BindingFlags.NonPublic);
