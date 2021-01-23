    private void RegisterForNotification(string propertyName, FrameworkElement element, PropertyChangedCallback callback)
    {
      //Bind to a dependency property  
      Binding b = new Binding(propertyName) { Source = element };
            if (AttachedProperty == null)
            {
              AttachedProperty = DependencyProperty.RegisterAttached(
              "ListenAttached" + propertyName,
              typeof(object),
              typeof(MainWindow),
              new PropertyMetadata(callback));
            }
      element.SetBinding(AttachedProperty, b);
    }
