    config.EnableSystemDiagnosticsTracing();
    config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
    config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
    config.Formatters.Remove(config.Formatters.XmlFormatter);
