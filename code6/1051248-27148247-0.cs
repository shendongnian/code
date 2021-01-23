    private void ShowResult(string json)
    {
        try
        {
             if (string.IsNullOrEmpty(json)) return; // no need to get an exception for that
            
             Response.Write(json);
            
        }
        catch 
        { 
            
        }
        finally
        {
            Response.End();
        }
    
    }
