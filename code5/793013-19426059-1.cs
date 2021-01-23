    public BindableRichTextBox()
    {
        this.RegisterForNotification("Xaml", this, (d,e) => ((BindableRichTextBox)d).Text = e.NewValue);
    }
    public void RegisterForNotification(string propertyName, FrameworkElement element, PropertyChangedCallback callback)
    {
        var binding = new Binding(propertyName) { Source = element };
        var property = DependencyProperty.RegisterAttached(
            "ListenAttached" + propertyName,
            typeof(object),
            typeof(UserControl),
            new PropertyMetadata(callback));
        element.SetBinding(property, binding);
    }
    
