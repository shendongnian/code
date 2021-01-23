    private static void AssignCredentials(WebClient wc, string userName, string password, string domain)
    {
        if (Is.NotEmptyString(userName))
        {
            wc.Credentials = Is.EmptyString(domain)
                                    ? new NetworkCredential(userName, password)
                                    : new NetworkCredential(userName, password, domain);
        }
    } 
