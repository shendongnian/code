    XmlDocument doc = new XmlDocument();
    doc.Load("xmlfile1.xml");
    
    string databasename = doc.DocumentElement.Name;
    
    foreach (XmlNode node in doc.SelectNodes("/" + databasename + "/*[starts-with(name(), 'SourceTableName')]"))
    {
        string tablename = node.Attributes["targetTable"].Value;
        string Columns = "";
        string Values = "";
    
        foreach (XmlNode field in node.SelectNodes("Field"))
        {
            Columns += (!string.IsNullOrEmpty(Columns) ? ", " : "") + field.Attributes["targetField"].Value;
            Values += (!string.IsNullOrEmpty(Values) ? ", " : "") + "'" + field.InnerText + "'";
        }
        //Generate insert statement
        string statement = string.Format("Insert Into {0}.{1} ({2}) Values ({3})",
                                        databasename,
                                        tablename,
                                        Columns,
                                        Values);
    
        Console.WriteLine(statement);
    }
