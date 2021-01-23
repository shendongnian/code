    public class MembershipSetting
    {
        /// <summary>
        /// Gets or sets the name of the setting.
        /// </summary>
        public string SettingName { get; set; }
    
        /// <summary>
        /// Gets or sets the setting value.
        /// </summary>
        public string SettingValue { get; set; }
    }
      private List<MembershipSetting> GetMembershipSetting()
        {
            List<MembershipSetting> settings = new List<MembershipSetting>
                                {
                                    new MembershipSetting {SettingName = "Dafult Membership Provider", SettingValue = Membership.Provider.ToString() },
                                    new MembershipSetting {SettingName = "Minimum Required Password Length", SettingValue = Membership.MinRequiredPasswordLength.ToString(CultureInfo.InvariantCulture) },
                                    new MembershipSetting {SettingName = "Minimum Required Non Alphanumeric Characters",SettingValue = Membership.MinRequiredNonAlphanumericCharacters.ToString(CultureInfo.InvariantCulture)},
                                    new MembershipSetting {SettingName = "Password reset enabled", SettingValue = Membership.EnablePasswordReset.ToString()},
                                    new MembershipSetting {SettingName = "Maximum Invalid Password Attempts",SettingValue = Membership.MaxInvalidPasswordAttempts.ToString(CultureInfo.InvariantCulture) },
                                    new MembershipSetting {SettingName = "Attempt windows",SettingValue = Membership.PasswordAttemptWindow.ToString(CultureInfo.InvariantCulture)},
                                    new MembershipSetting {SettingName = "applicationName",SettingValue = Membership.ApplicationName.ToString(CultureInfo.InvariantCulture)}
                                };
    
            return settings;
        }
