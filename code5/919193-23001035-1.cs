    var plugins = new List<Plugin>(new[]
    {
        new Plugin
        {
            Name = "plugin1",
            Settings = new List<PluginSetting>(new[]
            {
                new PluginSetting {Name = "volume", Value = 1.0d},
                new PluginSetting {Name = "soundSystemType", Value = "THX"}
            })
        }
    });
    string serializeObject = JsonConvert.SerializeObject(plugins, Formatting.Indented);
