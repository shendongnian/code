    var OverridesName = "FOO";
    var TechniqueName = "BAZ";
    IQueryable<TechniqueSetting> tSettings;
    if (OverridesName.Equals("Default", StringComparison.InvariantCultureIgnoreCase))
    {
        // Get a list of TechniqueSettings that have this name and are default
        tSettings = techniqueSettings.Where(t => t.Override == OverridesName && t.Technique == TechniqueName);
    }
    else
    {
        // Get a list of TechniqueSettings Id that are overridden 
        //  The ImageSettingOverrides have the same override 
        var overriddenIDs = techniqueSettings.Where(t => t.Technique == TechniqueName && t.Override == "Default")
                                             .Join(
                                                 imageSettingOverrides.Where(
                                                     iSettingsOverrides =>
                                                     iSettingsOverrides.Override == OverridesName),
                                                 tSetting => tSetting.Id,
                                                 iSettings => iSettings.TechniqueSettingsId,
                                                 (tSetting, iSettingsOverrides) => tSetting.Id);
        // Get a list of techniqueSettings that match the override and TechniqueName but are not part of the overriden IDs
        tSettings =
            techniqueSettings.Where(
                t =>
                t.Technique == TechniqueName && !overriddenIDs.Contains(t.Id) &&
                (t.Override == OverridesName || t.Override == "Default"));
    }
    // Now get a list of SettingKeyValues
    var settings = tSettings.Join(SettingKeyValues, tSetting => tSetting.SettingKeyId,
                                  sKeyValues => sKeyValues.Id, (tSetting, sKeyValues) => sKeyValues)
                            .Distinct();
