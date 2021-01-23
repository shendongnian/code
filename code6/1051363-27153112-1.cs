    // Instantiate the type.
    ConstructorInfo info = type.GetConstructor(System.Type.EmptyTypes);
    Control control = (Control)info.Invoke(null);
    // Get the template.
    ControlTemplate template = control.Template;
    // Get the XAML for the template.
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent = true;
    StringBuilder sb = new StringBuilder();
    XmlWriter writer = XmlWriter.Create(sb, settings);
    XamlWriter.Save(template, writer);
    // Display the template.
    someControl.Text = sb.ToString();
