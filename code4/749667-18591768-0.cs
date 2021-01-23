    private class MembershipSetting
        {
            public string settingName { get; set; }
            public string settingValue{ get; set; }
        }
        private void GetMembershipSetting()
        {
            var settings = new List<MembershipSetting>
                                {
                                    new MembershipSetting {settingName = "Dafult Membership Provider", settingValue = Membership.Provider.ToString() },
                                    new MembershipSetting {settingName = "Minimum Required Password Length", settingValue = Membership.MinRequiredPasswordLength.ToString(CultureInfo.InvariantCulture) },
                                    new MembershipSetting {settingName = "Minimum Required Non Alphanumeric Characters",settingValue = Membership.MinRequiredNonAlphanumericCharacters.ToString(CultureInfo.InvariantCulture)},
                                    new MembershipSetting {settingName = "Password reset enabled", settingValue = Membership.EnablePasswordReset.ToString()},
                                    new MembershipSetting {settingName = "Maximum Invalid Password Attempts",settingValue = Membership.MaxInvalidPasswordAttempts.ToString(CultureInfo.InvariantCulture) },
                                    new MembershipSetting {settingName = "Attempt windows",settingValue = Membership.PasswordAttemptWindow.ToString(CultureInfo.InvariantCulture)}
                                };
        }
