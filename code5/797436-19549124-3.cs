    IDataProtectionProvider provider = app.GetDataProtectionProvider();
    if (provider != null)
    {
        manager.PasswordResetTokens = new DataProtectorTokenProvider(provider.Create("PasswordReset"));
        manager.UserConfirmationTokens = new DataProtectorTokenProvider(provider.Create("ConfirmUser"));
    }
