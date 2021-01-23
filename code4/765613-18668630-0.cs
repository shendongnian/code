    using (System.Data.SqlClient.SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["fbgame"].ConnectionString))
        using (System.Data.SqlClient.SqlCommand cmd = c.CreateCommand())
        {
            cmd.CommandText = "procGetPlayerScore";
            cmd.CommandType = CommandType.StoredProcedure;
    
            c.Open();
    
            System.Xml.XmlReader r = cmd.ExecuteXmlReader();
            XmlDocument document = new XmlDocument();
            document.Load(r);
            
            Response.ContentType = "text/xml";
            document.Save(Response.Output);
    
            c.Close();
        }
    }
