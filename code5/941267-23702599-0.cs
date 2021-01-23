    public static IEnumerable<Cookie> GetAllCookies(CookieContainer cookieContainer)
    {
        var domainTable = (Hashtable)cookieContainer
                                .GetType()
                                .InvokeMember(
                                    name: "m_domainTable",
                                    invokeAttr: BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance,
                                    binder: null,
                                    target: cookieContainer,
                                    args: new object[] { });
        return domainTable.Keys.Cast<string>()
                    .Select(d => cookieContainer.GetCookies(new Uri("http://" + d.TrimStart('.'))))
                    .SelectMany(c => c.Cast<Cookie>());
                        
    }
