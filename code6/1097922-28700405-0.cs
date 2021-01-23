    try
    {
        XmlNode db = _xml.SelectSingleNode("root/database");
    
    
        string usr = db.SelectSingleNode("username").InnerText;
        string psw = db.SelectSingleNode("password").InnerText;
        string srvr = db.SelectSingleNode("server").InnerText;
        string dbn = db.SelectSingleNode("dbname").InnerText;
    
        //Here a FormatException can be thrown by both these Parse()
        //And I need to know which is the caller in order to display the correct error message
        bool clean_db;
    
        	try
        	{
        		clean_db = Boolean.Parse(db.Attributes["clean"].Value);
        	}
        	catch
        	{
        		throw new Exception ("clean exception");
        	}
        	
        	bool functions;
        
        	try
        	{
        		functions = Boolean.Parse(db.Attributes["insertFunctions"].Value);
        	}
        	catch
        	{
        		throw new Exception ("function exception");
        	}
        
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
