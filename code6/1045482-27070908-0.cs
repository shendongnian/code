    class ZIndexItemsControl : ItemsControl
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            FrameworkElement source = element as FrameworkElement;
            source.SetBinding(Canvas.ZIndexProperty, new Binding { Path = new PropertyPath("ZIndex") });
            // source.SetValue(Canvas.ZIndexProperty, 2);
            source.SetBinding(AutomationProperties.AutomationIdProperty, new Binding { Path = new PropertyPath("AutomationId") });
            source.SetBinding(AutomationProperties.NameProperty, new Binding { Path = new PropertyPath("AutomationName") });
        }
    }
