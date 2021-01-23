    // Intranet
    private const string REG_KEY_IE_ZONE_1 = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\1";
    // Trusted
    private const string REG_KEY_IE_ZONE_2 = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\2";
    // Internet
    private const string REG_KEY_IE_ZONE_3 = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3";
    // Restricted
    private const string REG_KEY_IE_ZONE_4 = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\4";
    public static void SetIESecurityToProtected()
    {
        // 3 is off, 0 is on
        try
        {
            // Intranet
            if ((int)Registry.GetValue(REG_KEY_IE_ZONE_1, "2500", -1) == 3)
            {
                Registry.SetValue(REG_KEY_IE_ZONE_1, "2500", 0);
            }
            // Trusted
            if ((int)Registry.GetValue(REG_KEY_IE_ZONE_2, "2500", -1) == 3)
            {
                Registry.SetValue(REG_KEY_IE_ZONE_2, "2500", 0);
            }
            // Internet
            if ((int)Registry.GetValue(REG_KEY_IE_ZONE_3, "2500", -1) == 3)
            {
                Registry.SetValue(REG_KEY_IE_ZONE_3, "2500", 0);
            }
            // Restricted
            if ((int)Registry.GetValue(REG_KEY_IE_ZONE_4, "2500", -1) == 3)
            {
                Registry.SetValue(REG_KEY_IE_ZONE_4, "2500", 0);
            }
        }
        catch (Exception e)
        {
            // handle your exception or record it...
        }
    }
