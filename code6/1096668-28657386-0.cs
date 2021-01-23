    public XmlDocument productsAll()
    {
        // define connection string
        string conString = "Data Source=my_db.com;Integrated Security=True";
        
        // define SQL query to use 
        string query = "SELECT ID AS '@ID', Name FROM dbo.Products FOR XML PATH('Product'), ROOT('Products')";
        
        // set up connection and command objects
        using (SqlConnection sqlConn = new SqlConnection(conString))
        using (SqlCommand sqlCmd = new SqlCommand(query, sqlConn))
        {
           // open connection
           sqlConn.Open();
           
           // execute query, read out the XML from the T-SQL query
           string xmlContents = sqlCmd.ExecuteScalar().ToString();
           
           // close connection
           sqlConn.Close();
           
           // parse XML received from SQL Server into a XmlDocument and return
           XmlDocument xmlDom = new XmlDocument();
           xmlDom.LoadXml(xmlContents);
           
           return xmlDom;
        }
    }
