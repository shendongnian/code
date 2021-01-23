    [System.Flags]
    public enum AuthenticationSchemes
    {
        None = 0,
        Digest = 1,
        Negotiate = 2,
        Ntlm = 4,
        IntegratedWindowsAuthentication = Ntlm | Negotiate,
        Basic = 8,
        Anonymous = 32768,
    }
