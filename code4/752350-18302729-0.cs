    public class ProfileManager : ProfileBase
    {
    public ProfileManager() : base()
    {
    	           
    }
    
    [SettingsAllowAnonymous(false)]
    [ProfileProvider("AspNetSqlProfileProvider")]
    public string DisplayName {
        get
        {
            return base["DisplayName"].ToString();
        }
        set
        {
            base["DisplayName"] = value;
            this.Save();
        }
    }
    }
