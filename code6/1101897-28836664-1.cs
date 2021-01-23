    XmlDocument xml = new XmlDocument();
    xml.LoadXml(sResponse); //Your XML Document
    foreach (XmlNode row in xml.ChildNodes) //Loop the child nodes
    {
        Serial_x0020_Number = row.SelectSingleNode("Serial_x0020_Number").InnerText; //Get value of each node
        Date = row.SelectSingleNode("Date").InnerText;
        Voltage1 = row.SelectSingleNode("Voltage1").InnerText;
        Voltage2 = row.SelectSingleNode("Voltage2").InnerText;
        Voltage3 = row.SelectSingleNode("Voltage3").InnerText;
        Voltage4 = row.SelectSingleNode("Voltage4").InnerText;
        Passed= row.SelectSingleNode("Passed").InnerText;
        //Insert comand here 
        string sSQL = "INSERTINTO TABLENAME(SN,Date,Voltage1, Voltage2,Voltage3,Voltage4,Passed) VALUES ('" + Date + "','" + Voltage1+ "','" + Voltage2+ "','" + Voltage3+ "','" + Voltage4+ "','" + PAssed + "');";
        //You will have to use a connection string and process the SQL in the typical way you are use to. 
    } 
