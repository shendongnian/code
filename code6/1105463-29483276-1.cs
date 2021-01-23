    [global::System.Configuration.UserScopedSettingAttribute()]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Configuration.DefaultSettingValueAttribute("fName; lName")]
    public Person Test
    {
        get {
            return ((Person)(this["Test"]));
        }
        set {
            this["Test"] = value;
        }
    }
