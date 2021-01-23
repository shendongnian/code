    try
    {
        XmlNode db = _xml.SelectSingleNode("root/database");
    
    
        string usr = db.SelectSingleNode("username").InnerText;
        string psw = db.SelectSingleNode("password").InnerText;
        string srvr = db.SelectSingleNode("server").InnerText;
        string dbn = db.SelectSingleNode("dbname").InnerText;
    
        //Here a FormatException can be thrown by both these Parse()
        //And I need to know which is the caller in order to display the correct error message
        bool clean_db = ParseDbAttributeValue(db.Attributes["clean"].Value);
    	
    	bool functions = ParseDbAttributeValue(db.Attributes["insertFunctions"].Value);
    
        return new DatabaseConfiguration(usr, psw, srvr, dbn, clean_db, functions);
    }
    catch (XPathException)
    {
        Console.WriteLine("<database> node is missing");
    }
    catch(FormatException e)
    {
        //Here I'm supposed to do something to get the caller
        Console.WriteLine("Error message");
    }
    
    private bool ParseDbAttributeValue(object myValue)
    {
    	return Boolean.Parse(myValue);
    }
