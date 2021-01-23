    ComponentControl<int> component = new ComponentControl<int>() { A = "A", B = 1, C = 2 };
    Type type = component.GetType();            
    dynamic proxyType = DynamicProxyGenerator.GetInstanceFor<ComponentControl<int>>(component);            
    
    foreach (var f in type.GetFields().Where(f => f.IsPublic))
    {
        TextBox control = new TextBox();
        Binding binding = new Binding("Text", proxyType, f.Name, false, DataSourceUpdateMode.OnPropertyChanged);
                
        control.DataBindings.Add(binding);
    }
