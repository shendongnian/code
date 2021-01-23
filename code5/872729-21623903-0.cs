        // Parse the file.  
        try
        {
            while (reader.Read()) ;
        }
        catch (XmlException err)
        {
            ;
        }
        finally
        {
            reader.Close();
        }
    }
