    [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool InternetSetCookie(string url, string name, string data);
    public static bool SetWinINETCookieString(string url, string name, string data)
    {
       return Form1.InternetSetCookie(url, name, data);
    }
