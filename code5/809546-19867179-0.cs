    public static string GetNick()
    {
        ClientClass prog = new ClientClass();
        XDocument doc = XDocument.Load(prog.settingsFile);
        return (string)doc.Descendants("settings").Elements("nick").FirstOrDefault();
    }
