            var result =
            (
                from ts in techniqueSettings
                // For only selected technique
                where ts.Technique.Equals("BAZ", StringComparison.InvariantCultureIgnoreCase)
                // Join with SettingsKeyValues
                join skv in settingKeyValues on ts.SettingKeyId equals skv.Id
                // intermediate object
                let item = new { ts, skv }
                // Group by SettingKeyValues.Setting to have only one 'Wait' in output
                group item by item.skv.Setting into itemGroup
                // Order items inside each group accordingly to Override - non-Default take precedence
                let firstSetting = itemGroup.OrderBy(i => i.ts.Override.Equals("Default") ? 1 : 0).First()
                // Return only SettingKeyValue
                select firstSetting.skv
             )
             .ToList();   
 
