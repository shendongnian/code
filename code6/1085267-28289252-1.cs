    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        .....
    
        DependencyObject dependencyObject = service.TargetObject as DependencyObject;
        if (dependencyObject == null)
            return this;
    
        PropertyChangeNotifier notifier = new PropertyChangeNotifier(dependencyObject,
                       TranslateExtension.UidProperty);
        notifier.ValueChanged += (s, e) => BindDictionary();
    
        .......
    }
