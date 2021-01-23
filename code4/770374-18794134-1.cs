    using (WebClient client = new WebClient())
    {
        client.Encoding = Encoding.UTF8;
        string vysledek = client.DownloadString("http://www.cnb.cz/cs/financni_trhy/devizovy_trh/kurzy_devizoveho_trhu/denni_kurz.txt?date=13.09.2013");
        var table = vysledek.Split(new char[] { '\n', '\r' })
                    .Select(line => line.Split('|').ToList())
                    .Skip(2)
                    .ToList();
    }
