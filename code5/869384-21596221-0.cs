    BindingSource bindingSource = new BindingSource((System.Collections.Specialized.StringCollection)Properties.Settings.Default.Units, "");
    if(!bindingSource.Contains(someSavedValue))
    {
        bindingSource.Insert(0, someSavedValue));
    }
    this.cboUnit.DataSource = bindingSource;
