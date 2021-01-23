    private enum UserTypeEnum
    {
        [Description("Administrator")]
        Admin,
        [Description("Moderator")]
        Mod
    };
    public UserTypeEnum UserType;
    public string UserTypeStr { get {return UserType.ToString();} }
