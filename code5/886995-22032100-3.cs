    Settings setting_ = .... // not null
    var changeName = !string.IsNullOrEmpty(setting_.Name);
    var changeSetting = setting_.Settings != null;
    var changeLocation = setting_.Location != null;
    if (changeName || changeSetting || changeLocation)
    {
        foreach (var item in ItemCollection)
        {
            var tt1 = item.getTT1();
            var tt2 = item.getTT2();
            if (tt1 == null || tt2 == null)
            {
                continue;
            }
            if (changeName)
            {
                tt2.Rename(tt1, setting_.Name);
            }
 
            if (changeSetting)
            {
                tt2.ChangeSettings(tt1, settings_.Settings);
            }
            if (changeLocation)
            {
                tt2.ChangeLocation(tt1, settings_.Location);
            }
        }
    }
