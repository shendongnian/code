    public static string GetIPAddress(string name)
    {
        Resolver resolver = new Resolver();
        resolver.DnsServer = ((App)App.Current).CurrentConfiguration.DNSAddress;
        resolver.Recursion = true;
        resolver.Retries = 3;
        resolver.TimeOut = 1;
        resolver.TranportType = TransportType.Udp;
        Response response = resolver.Query(name, QType.A);
        if (response.header.ANCOUNT > 0)
        {
             return ((AnswerRR)response.Answer[0]).RECORD.ToString();
        }
        return null;
    }
