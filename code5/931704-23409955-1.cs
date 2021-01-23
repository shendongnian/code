    var defaultGroup = techniqueGroups
       .Where(grp => grp.Key.Equals("Default", StringComparison.InvariantCultureIgnoreCase))
       .Aggregate(overridesGroup,
          (overrides, defaults) => {
             var settings = new List<TechniqueSetting>();
             foreach (var setting in defaults) {
                if (overrides.Any(o => o.SettingKey.Key == setting.SettingKey.Key)) {
                   continue;
                }
                settings.Add(setting);
                
             }
             return settings.GroupBy(s => s.Override).First();
          },
          setting => setting);
