    //I'm assuming these are your variables for each IQueryable
    IQueryable<TechniqueSetting> techniqueSettings;
    IQueryable<ImageSettingOverride> imageSettingOverrides;
    IQueryable<SettingKeyValue> settingKeyValues;
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
                                                 tSetting => tSetting.SettingKeyId,
                                                 iSettings => iSettings.TechniqueSettingsId,
                                                 (tSetting, iSettingsOverrides) => tSetting.Id);
        // Get a list of techniqueSettings that match the override and TechniqueName but are not part of the overriden IDs
        tSettings =
            techniqueSettings.Where(
                t =>
                t.Technique == TechniqueName && !overriddenIDs.Contains(t.Id) &&
                (t.Override == OverridesName || t.Override == "Default"));
    }
    // From expected results seems you just want techniqueSettings and that's what would be in techniqueSettings right now.
    // If you want a list of SettingKeyValues (which is what is stated in the questions we just need to join them in now)
    var settings = tSettings.Join(settingKeyValues, tSetting => tSetting.SettingKeyId,
                                  sKeyValues => sKeyValues.Id, (tSetting, sKeyValues) => sKeyValues)
                            .Distinct();
