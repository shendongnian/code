    XDocument doc = XDocument.Load(response.GetResponseStream());
    XNamespace df = "http://tempuri.org/";
    
    List<payment_history> ph = doc.Descendants(df + "PaymentHistory_ST")
                     .Select(g => new payment_history
                     {
                         tTRANSDATE = (DateTime)g.Element(df + "tTRANSDATE"),
                         tPAIDTO = (DateTime)g.Element(df + "tPAIDTO"),
                         dAMOUNT = (double)g.Element(df + "dAMOUNT"),
                         dBALANCE = (double)g.Element(df + "dBALANCE"),
                         TRANSKIND = (string)g.Element(df + "TRANSKIND")
                     }).ToList();
