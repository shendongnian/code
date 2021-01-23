      public PasswordModel
    {
        public string Password { get; set; }
    
        public string PasswordConfirm { get; set; }
    }
    public UserSettingViewMode : UserBaseModel
    {
        public PasswordModel Password { get; set; }
    
    }
