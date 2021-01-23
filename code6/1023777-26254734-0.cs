    Dictionary<string, string> userguid = new Dictionary<string, string>();
    XDocument XMLDoc =
        new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement(
                "NewDataSet",
                new XElement(
                    "Users",
                    new XElement("UserID", userid),
                    new XElement("FullName", "anyone"),
                    new XElement("UserName", "anyone"),
                    new XElement("Password", 123),
                    new XElement("Description", "anyone"),
                    new XElement("DomainName", string.Empty),
                    new XElement("Mailbox_Size", 20),
                    new XElement("Enabled", "True"),
                    new XElement("Permissions", 14),
                    new XElement("CreationTime", "2011-07-19T17:45:58.53125+05:30")
                    ),
                userNames.Select(
                                 (item, value) =>{
                                     userguid.Add(userid, emailAddresses[value].Trim());
                                     return new XElement(
                                         "Users",
                                         new XElement("UserID", Guid.NewGuid().ToString("N")),
                                         new XElement("FullName", item.Trim()),
                                         new XElement("UserName", item.Trim()),
                                         new XElement("Password", passwords[value].Trim()),
                                         new XElement("Description", item.Trim()),
                                         new XElement("DomainName", string.Empty),
                                         new XElement("Mailbox_Size", 20),
                                         new XElement("Enabled", "True"),
                                         new XElement("Permissions", 14),
                                         new XElement("CreationTime", "2011-07-19T17:45:58.53125+05:30"));
                                 }
                    )
                ));
