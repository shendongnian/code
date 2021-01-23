    [global::System.Configuration.UserScopedSettingAttribute()]
    [global::System.Configuration.SettingsSerializeAs(global::System.Configuration.SettingsSerializeAs.Binary)]
    [global::System.Configuration.DefaultSettingValueAttribute("")]
    public List<FoodType> FoodTypes
    {
        get
        {
            return this["FoodTypes"] as List<FoodType>;
        }
        set
        {
            this["FoodTypes"] = value;
        }
    }
