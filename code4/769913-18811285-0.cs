    var binding = new Binding();
    binding.Source = childControl;
    binding.Mode = BindingMode.OneWay;
    binding.Path = new PropertyPath("(0)", ResourceUIElement.ResourcePackageProperty);
    binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    BindingOperations.SetBinding(proxy, Proxy.ValueProperty, binding);
