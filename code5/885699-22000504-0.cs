    Configure(component => component.UsingFactoryMethod(
                    () =>
                    {
                        var attrib = (AppSettingsFromConfigAttribute)Attribute.GetCustomAttribute(component.Implementation, typeof(AppSettingsFromConfigAttribute));
                        var prop = new PropertyDescriptor();
                        prop.AddBehavior(new AppSettingsBehavior(attrib.KeyPrefix));
                        var meta = configFactory.GetAdapterMeta(component.Implementation);
                        foreach (var entry in meta.Properties)
                        {
                            entry.Value.Fetch = true;
                        }
                        return meta.CreateInstance(new NameValueCollectionAdapter(ConfigurationManager.AppSettings), prop);
                    })));
