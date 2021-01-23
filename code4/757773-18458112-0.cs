    public static string LostPasswordEmailFrom
    {
        get
        { 
            var kvp = SiteSettings.GetSettingKeyValuePair();
    
            if (kvp == null || !kvp.ContainsKey("LA_MembershipProvider_lostPasswordEmailFrom"))
                return Globals.Settings.FromEmail;
            return kvp["LA_MembershipProvider_lostPasswordEmailFrom"];
        }
    }
