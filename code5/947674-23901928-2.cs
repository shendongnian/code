    try
    {
        Regex.Replace(hashedfile1name, @"[^\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
    }
    catch (RegexMatchTimeoutException)
    {
        hashedfile1name = "";
    }
