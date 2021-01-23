    XmlDocument config = new XmlDocument();
    string configName = Assembly.GetExecutingAssembly().Location + ".config";
    config.Load(configName);
    XmlNode databaseNode = config.DocumentElement.SelectSingleNode(sectionName + "/" + DatabaseName);
    if (databaseNode != null)
    {
    	databaseNode.Attributes[Database.PasswordName].Value = value.Database.PasswordEnc;
    }
    //another nodes changes are skipped
    config.Save(configName);
