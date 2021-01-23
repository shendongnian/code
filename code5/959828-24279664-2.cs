    Binding backgroundBinding = new Binding("BackColor", dataSource, "selectedColor", false, DataSourceUpdateMode.OnPropertyChanged);
    backgroundBinding.Parse += OnParseBackgroundBinding;
    backgroundBinding.Format += OnFormatBackgroundBinding;
    this.panel1.DataBindings.Add(backgroundBinding);
    private void OnParseBackgroundBinding(object sender, ConvertEventArgs args)
    {
        // this is called when the value of the binding changes
        Color background = (Color)args.Value;
        // do your conversion here...
        args.Value = ...
    }
    private void OnFormatBackgroundBinding(object sender, ConvertEventArgs args)
    {
        // this is called when the property of the binding changes
        // do conversion here if necessary...
    }
