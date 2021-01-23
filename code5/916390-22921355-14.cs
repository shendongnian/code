    public static void EncryptMethod()
    {
        var fileName = @"c:/text.xml";
        XDocument doc = new XDocument();
        XElement xml = new XElement("Info",
            new XElement("DatabaseServerName", "txtServerName.Text"),
            new XElement("DatabaseUserName", "txtDatabaseUserName.Text"),
            new XElement("DatabasePassword", "txtDatabasePassword.Text"),
            new XElement("ServiceAccount", "txtAccount.Text"),
            new XElement("ServicePassword", "txtServicePassword.Text"),
            new XElement("RegistrationCode", "txtRegistrationCode.Text"));
        doc.Add(xml);
        var sKey = "LvtZELDrB394hbSOi3SurLWAvC8adNpZiJmQDJHdfJU=";
        var aesKey = Convert.FromBase64String(sKey);
        string encyptedText = EncryptStringToBase64String(doc.ToString(), aesKey);
        File.WriteAllText(fileName, encyptedText);
    }
    public static void DecryptMethod()
    {
        var fileName = @"c:/text.xml";
        string sKey = "LvtZELDrB394hbSOi3SurLWAvC8adNpZiJmQDJHdfJU=";
        Byte[] keyBytes = Convert.FromBase64String(sKey);
        var encryptedText = File.ReadAllText(fileName, new ASCIIEncoding());
        string xmlStr = DecryptStringFromBase64String(encryptedText, keyBytes);
        using (XmlReader reader = XmlReader.Create(new StringReader(xmlStr)))
        {
            reader.ReadToFollowing("DatabaseServerName");
            Console.WriteLine(reader.ReadElementContentAsString());
            reader.ReadToFollowing("DatabaseUserName");
            Console.WriteLine(reader.ReadElementContentAsString());
            reader.ReadToFollowing("DatabasePassword");
            Console.WriteLine(reader.ReadElementContentAsString());
            reader.ReadToFollowing("RegistrationCode");
            Console.WriteLine(reader.ReadElementContentAsString());
        }
    }
